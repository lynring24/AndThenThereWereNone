//오브젝트 zoom in 상태일 때만 트리거 발생하는 클래스
//즉, 메인 카메라 말고 오브젝트 카메라가 켜져 있을 시 발생
//RaycastHit쓰니까 오브젝트에 collider 설정되어 있어야함

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectTrigger : MonoBehaviour
{
    public static bool key = false;
    public static bool note4 = false;
    public static int eventCount = 0;
    public Camera MainCamera, ObjectCamera;//오브젝트와 상속 관계에 있는 카메라
    public AudioSource gunSound, hammerSound, phoneSound, lightSound, pencilSound, clockSound, keySound;
    bool shelfTri, LightTri, MirrorTri, PhoneTri, HangerTri;
    int LCount = 0, RCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = ObjectCamera.ScreenPointToRay(Input.mousePosition);
            isTrigger(ray);
        }
        if (GetComponent<Camera>().enabled == false)
        {
            shelfTri = false;
            PhoneTri = false;
            MirrorTri = false;
            LightTri = false;
            HangerTri = false;
        }
    }

    void isTrigger(Ray ray)
    {
        RaycastHit hitObj;
        if (Physics.Raycast(ray, out hitObj, Mathf.Infinity))
        {//시작지점, 방향, 길이
            if (shelfTri && ObjectCamera.enabled)
            {

                //충돌 발생함&&오브젝트 카메라 켜짐&&RaycastHit으로 반환된 오브젝트 태그가 내가 생각한 그 오브젝트와 equals인지
                /*do something you want*/
                if (hitObj.transform.tag.Equals("GUN"))
                {
                    hitObj.transform.gameObject.SetActive(false);
                    ItemDatabase.db.Add("gun");
                    gunSound.Play();
                    GameObject.Find("gunTri").gameObject.GetComponent<TextBoxTrigger_5>().enabled = true;
                    //ClickedSlot ("gun");
                    GameObject.Find("gunImage").gameObject.GetComponent<RawImage>().enabled = true;
                    GameObject.Find("BackImage").gameObject.GetComponent<Image>().enabled = true;
                }
                else if (hitObj.transform.tag.Equals("HAMMER"))
                {
                    hitObj.transform.gameObject.SetActive(false);
                    ItemDatabase.db.Add("hammer");
                    hammerSound.Play();
                    GameObject.Find("hammerTri").gameObject.GetComponent<TextBoxTrigger_5>().enabled = true;
                    GameObject.Find("hammerImage").gameObject.GetComponent<RawImage>().enabled = true;
                    GameObject.Find("BackImage").gameObject.GetComponent<Image>().enabled = true;
                    //ClickedSlot ("Hammer");					
                }
            }
            else
                shelfTri = true;

            if (hitObj.transform.tag.Equals("LAMPL") || hitObj.transform.tag.Equals("LAMPR"))
            {
                if (LightTri)
                {
                    //충돌 발생함&&오브젝트 카메라 켜짐&&RaycastHit으로 반환된 오브젝트 태그가 내가 생각한 그 오브젝트와 equals인지
                    lightSound.Play();


                    if (hitObj.transform.tag.Equals("LAMPR"))
                    {
                        lightSound.Play();
                        hitObj.transform.FindChild("LightR").gameObject.SetActive(true);
                        RCount++;
                    }
                    if (hitObj.transform.tag.Equals("LAMPL"))
                    {
                        hitObj.transform.FindChild("LightL").gameObject.SetActive(true);
                        LCount++;
                    }
                    if (LCount >= 1 && RCount >= 1)
                    { // 핸드폰을 줍는다.
                        note4 = true;
                        GameObject.Find("bedTri").gameObject.GetComponent<TextBoxTrigger_5>().enabled = true;
                        GameObject.Find("BedR").transform.FindChild("note4").gameObject.SetActive(true);
                        ObjectCamera.transform.rotation = Quaternion.Euler(10, 110, 0);
                        ObjectCamera.transform.position.Set(1580f, 3778f, -280);

                        //GameObject.Find ("LightUI").transform.FindChild ("LightBack").gameObject.SetActive(true);
                    }
                }
                else
                    LightTri = true;
            }
            if (hitObj.transform.tag.Equals("NOTE4"))
            {
                if (PhoneTri)
                {
                    phoneSound.Play();
                    GameObject.Find("phoneTri").gameObject.GetComponent<TextBoxTrigger_5>().enabled = true;// 대화창
                    GameObject.Find("note4Image").gameObject.GetComponent<RawImage>().enabled = true;
                    GameObject.Find("BackImage").gameObject.GetComponent<Image>().enabled = true;
                    hitObj.transform.gameObject.SetActive(false);
                    ClickedSlot(hitObj.transform.gameObject.name);
                    ItemDatabase.db.Add("note4");
                    GameObject.Find("LightBack").GetComponent<Image>().enabled = true;
                }
                else
                    PhoneTri = true;
            }
            if (hitObj.transform.tag.Equals("CLOTH"))
            {
                if (HangerTri)
                {
                    if (note4)
                    {
                        pencilSound.Play();
                        GameObject.Find("Clothes").transform.FindChild("postit").gameObject.SetActive(true);
                        GameObject.Find("WallOrigin").transform.FindChild("Clock").gameObject.SetActive(true);
                        GameObject.Find("postTri").gameObject.GetComponent<TextBoxTrigger_5>().enabled = true;
                    }
                    else
                        GameObject.Find("clothTri").gameObject.GetComponent<TextBoxTrigger_5>().enabled = true;// 대화
                }
                else
                    HangerTri = true;

            }
            if (hitObj.transform.tag.Equals("CLOCK") || (hitObj.transform.tag.Equals("KEY")))
            {
                if (MirrorTri)
                {
                    if (hitObj.transform.tag.Equals("CLOCK"))
                    {
                        clockSound.Play();
                        GameObject.Find("Clock").transform.gameObject.SetActive(false);
                        GameObject.Find("KeyObj").transform.FindChild("Key").gameObject.SetActive(true);
                    }
                    else if (hitObj.transform.tag.Equals("KEY"))
                    {
                        key = true;
                        keySound.Play();
                        GameObject.Find("keyImage").gameObject.GetComponent<RawImage>().enabled = true;
                        GameObject.Find("BackImage").gameObject.GetComponent<Image>().enabled = true;
                        GameObject.Find("keyTri").gameObject.GetComponent<TextBoxTrigger_5>().enabled = true;
                        GameObject.Find("KeyObj").transform.FindChild("Key").gameObject.SetActive(false);
                        ItemDatabase.db.Add("Key");
                        keySound.Stop();
                    }
                }
                else
                    MirrorTri = true;
            }
        }
    }

    public void ClickedSlot(string strName)
    {
        for (int i = 0; i < 5; i++)
        {
            if (GameObject.Find("SlotV" + i).GetComponent<Image>().sprite.name == strName)
            {
                while (i < 4)
                {
                    GameObject.Find("SlotV" + i).GetComponent<Image>().sprite = GameObject.Find("SlotV" + (i + 1)).GetComponent<Image>().sprite;
                    i++;
                }
                GameObject.Find("SlotV" + i).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/f");
                ItemDatabase.itemCount -= 1;
                ItemDatabase.slotCount -= 1;
                break;
            }
        }
    }
}
