using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Room1_ObjectTrigger : MonoBehaviour {
    public Camera ObjectCamera;
    bool doorTri, keypadTri, bedTri, bigDrawerTri, tableTri, boxTri;

    //	bool epic1;
    bool clear = true;
    bool exit = false;

    int hammerCount;

    void Update() {

        triBoolDisable();

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = ObjectCamera.ScreenPointToRay(Input.mousePosition);
            isTrigger(ray);
        }

        //hammerCount
        HammerCount();

        //exitRoom1
        ExitRoom1();
    }

    void isTrigger(Ray ray)
    {
        RaycastHit hitObj;
        if (Physics.Raycast(ray, out hitObj, Mathf.Infinity) && hitObj.collider != null && ObjectCamera.enabled)
        {
            //1. Door Trigger
            DoorTri(hitObj);

            //2. Keypad Trigger->Door Zoom In 상태에서도 접근가능
            KeypadTri(hitObj);

            //3. Bed1 + Bed2 + Drawer Trigger
            BedTri(hitObj);

            //4. BigDrawer Trigger
            BigDrawerTri(hitObj);

            //5. Table + EpicItem Trigger
            TableTri(hitObj);

            //6. Box + Window Trigger
            BoxTri(hitObj);
        }
    }

    void triBoolDisable() {
        if (GetComponent<Camera>().enabled == false)
        {
            doorTri = false;
            keypadTri = false;
            bedTri = false;
            bigDrawerTri = false;
            tableTri = false;
            boxTri = false;
        }
    }

    void DoorTri(RaycastHit hitObj)
    {

        if (doorTri && GameObject.Find("DoorCamera").GetComponent<Camera>().enabled) {
            if (hitObj.transform.tag.Equals("Door"))
            {
                GameObject.Find("DoorDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                GameObject.Find("DoorLockedAudio").GetComponent<AudioSource>().Play();
            }
        } else
            doorTri = true;
    }

    void KeypadTri(RaycastHit hitObj) {
        if (keypadTri && ((GameObject.Find("DoorCamera").GetComponent<Camera>().enabled
                || GameObject.Find("KeypadCamera").GetComponent<Camera>().enabled)))
        {

            if (hitObj.transform.tag.Equals("Button1"))
            {
                GameObject.Find("ButtonAudio").GetComponent<AudioSource>().Play();
                if (GameObject.Find("Button1").GetComponent<Renderer>().material.color == Color.white)
                    GameObject.Find("Button1").GetComponent<Renderer>().material.color = Color.red;
                else if (GameObject.Find("Button1").GetComponent<Renderer>().material.color == Color.red)
                    GameObject.Find("Button1").GetComponent<Renderer>().material.color = Color.blue;
                else if (GameObject.Find("Button1").GetComponent<Renderer>().material.color == Color.blue)
                    GameObject.Find("Button1").GetComponent<Renderer>().material.color = Color.magenta;
                else
                    GameObject.Find("Button1").GetComponent<Renderer>().material.color = Color.white;
            }
            else if (hitObj.transform.tag.Equals("Button2"))
            {
                GameObject.Find("ButtonAudio").GetComponent<AudioSource>().Play();
                if (GameObject.Find("Button2").GetComponent<Renderer>().material.color == Color.white)
                    GameObject.Find("Button2").GetComponent<Renderer>().material.color = Color.red;
                else if (GameObject.Find("Button2").GetComponent<Renderer>().material.color == Color.red)
                    GameObject.Find("Button2").GetComponent<Renderer>().material.color = Color.blue;
                else if (GameObject.Find("Button2").GetComponent<Renderer>().material.color == Color.blue)
                    GameObject.Find("Button2").GetComponent<Renderer>().material.color = Color.magenta;
                else
                    GameObject.Find("Button2").GetComponent<Renderer>().material.color = Color.white;
            }
            else if (hitObj.transform.tag.Equals("Button3"))
            {
                GameObject.Find("ButtonAudio").GetComponent<AudioSource>().Play();
                if (GameObject.Find("Button3").GetComponent<Renderer>().material.color == Color.white)
                    GameObject.Find("Button3").GetComponent<Renderer>().material.color = Color.red;
                else if (GameObject.Find("Button3").GetComponent<Renderer>().material.color == Color.red)
                    GameObject.Find("Button3").GetComponent<Renderer>().material.color = Color.blue;
                else if (GameObject.Find("Button3").GetComponent<Renderer>().material.color == Color.blue)
                    GameObject.Find("Button3").GetComponent<Renderer>().material.color = Color.magenta;
                else
                    GameObject.Find("Button3").GetComponent<Renderer>().material.color = Color.white;
            }
            else if (hitObj.transform.tag.Equals("Button4"))
            {
                GameObject.Find("ButtonAudio").GetComponent<AudioSource>().Play();
                if (GameObject.Find("Button4").GetComponent<Renderer>().material.color == Color.white)
                    GameObject.Find("Button4").GetComponent<Renderer>().material.color = Color.red;
                else if (GameObject.Find("Button4").GetComponent<Renderer>().material.color == Color.red)
                    GameObject.Find("Button4").GetComponent<Renderer>().material.color = Color.blue;
                else if (GameObject.Find("Button4").GetComponent<Renderer>().material.color == Color.blue)
                    GameObject.Find("Button4").GetComponent<Renderer>().material.color = Color.magenta;
                else
                    GameObject.Find("Button4").GetComponent<Renderer>().material.color = Color.white;
            }
            else if (hitObj.transform.tag.Equals("Button5"))
            {
                GameObject.Find("ButtonAudio").GetComponent<AudioSource>().Play();
                if (GameObject.Find("Button5").GetComponent<Renderer>().material.color == Color.white)
                    GameObject.Find("Button5").GetComponent<Renderer>().material.color = Color.red;
                else if (GameObject.Find("Button5").GetComponent<Renderer>().material.color == Color.red)
                    GameObject.Find("Button5").GetComponent<Renderer>().material.color = Color.blue;
                else if (GameObject.Find("Button5").GetComponent<Renderer>().material.color == Color.blue)
                    GameObject.Find("Button5").GetComponent<Renderer>().material.color = Color.magenta;
                else
                    GameObject.Find("Button5").GetComponent<Renderer>().material.color = Color.white;
            }
            else if (hitObj.transform.tag.Equals("Button6"))
            {
                GameObject.Find("ButtonAudio").GetComponent<AudioSource>().Play();
                if (GameObject.Find("Button6").GetComponent<Renderer>().material.color == Color.white)
                    GameObject.Find("Button6").GetComponent<Renderer>().material.color = Color.red;
                else if (GameObject.Find("Button6").GetComponent<Renderer>().material.color == Color.red)
                    GameObject.Find("Button6").GetComponent<Renderer>().material.color = Color.blue;
                else if (GameObject.Find("Button6").GetComponent<Renderer>().material.color == Color.blue)
                    GameObject.Find("Button6").GetComponent<Renderer>().material.color = Color.magenta;
                else
                    GameObject.Find("Button6").GetComponent<Renderer>().material.color = Color.white;
            }
            else if (hitObj.transform.tag.Equals("Button7"))
            {
                GameObject.Find("ButtonAudio").GetComponent<AudioSource>().Play();
                if (GameObject.Find("Button7").GetComponent<Renderer>().material.color == Color.white)
                    GameObject.Find("Button7").GetComponent<Renderer>().material.color = Color.red;
                else if (GameObject.Find("Button7").GetComponent<Renderer>().material.color == Color.red)
                    GameObject.Find("Button7").GetComponent<Renderer>().material.color = Color.blue;
                else if (GameObject.Find("Button7").GetComponent<Renderer>().material.color == Color.blue)
                    GameObject.Find("Button7").GetComponent<Renderer>().material.color = Color.magenta;
                else
                    GameObject.Find("Button7").GetComponent<Renderer>().material.color = Color.white;
            }
            else if (hitObj.transform.tag.Equals("Button8"))
            {
                GameObject.Find("ButtonAudio").GetComponent<AudioSource>().Play();
                if (GameObject.Find("Button8").GetComponent<Renderer>().material.color == Color.white)
                    GameObject.Find("Button8").GetComponent<Renderer>().material.color = Color.red;
                else if (GameObject.Find("Button8").GetComponent<Renderer>().material.color == Color.red)
                    GameObject.Find("Button8").GetComponent<Renderer>().material.color = Color.blue;
                else if (GameObject.Find("Button8").GetComponent<Renderer>().material.color == Color.blue)
                    GameObject.Find("Button8").GetComponent<Renderer>().material.color = Color.magenta;
                else
                    GameObject.Find("Button8").GetComponent<Renderer>().material.color = Color.white;
            }
            else if (hitObj.transform.tag.Equals("Button9"))
            {
                GameObject.Find("ButtonAudio").GetComponent<AudioSource>().Play();
                if (GameObject.Find("Button9").GetComponent<Renderer>().material.color == Color.white)
                    GameObject.Find("Button9").GetComponent<Renderer>().material.color = Color.red;
                else if (GameObject.Find("Button9").GetComponent<Renderer>().material.color == Color.red)
                    GameObject.Find("Button9").GetComponent<Renderer>().material.color = Color.blue;
                else if (GameObject.Find("Button9").GetComponent<Renderer>().material.color == Color.blue)
                    GameObject.Find("Button9").GetComponent<Renderer>().material.color = Color.magenta;
                else
                    GameObject.Find("Button9").GetComponent<Renderer>().material.color = Color.white;
            }
        }
        else
            keypadTri = true;
    }

    void BedTri(RaycastHit hitObj) {
        if (bedTri && (GameObject.Find("BedCamera").GetComponent<Camera>().enabled))
        {
            if (hitObj.transform.tag.Equals("Bed1"))
            {
                GameObject.Find("BedAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("BedDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
            }
            else if (hitObj.transform.tag.Equals("Bed2"))
            {
                GameObject.Find("FabricAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("something").gameObject.SetActive(false);
            }
            else if (hitObj.transform.tag.Equals("Drawer"))
            {
                if (!GameObject.Find("Box").transform.FindChild("Key").gameObject.activeSelf)
                {
                    ClickedSlot("Key");
                    GameObject.Find("CabinetAudio").GetComponent<AudioSource>().Play();
                    GameObject.Find("Drawer").transform.FindChild("TopDrawer").gameObject.SetActive(true);
                }
                else {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    GameObject.Find("DrawerDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                }

            }
            else if (hitObj.transform.tag.Equals("Hammer"))
            {

                //Hammer 클릭시 사운드 재생
                GameObject.Find("GetAudio").GetComponent<AudioSource>().Play();
                //Hammer 클릭 시 인벤토리 연결
                ItemDatabase.db.Add(hitObj.transform.gameObject.name);
                //Hammer 클릭 시 이미지 활성화
                GameObject.Find("HammerWindowBack").gameObject.GetComponent<Image>().enabled = true;
                GameObject.Find("HammerImage").gameObject.GetComponent<RawImage>().enabled = true;
                //대화창 활성화
                GameObject.Find("HammerDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                GameObject.Find("Hammer").gameObject.SetActive(false);
                //hammerCount 초기화
                hammerCount = 0;
            }
            else if (hitObj.transform.tag.Equals("Paper"))
            {
                ItemDatabase.db.Add(hitObj.transform.gameObject.name);
                GameObject.Find("PaperAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("Paper1WindowBack").gameObject.GetComponent<Image>().enabled = true;
                GameObject.Find("Paper1Image").gameObject.GetComponent<RawImage>().enabled = true;

                GameObject.Find("PaperDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                GameObject.Find("Paper").gameObject.SetActive(false);
            }
            else if (hitObj.transform.tag.Equals("TopDrawer"))
            {
                GameObject.Find("CabinetAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("TopDrawer").gameObject.SetActive(false);
            }
        }
        else
            bedTri = true;
    }

    void BigDrawerTri(RaycastHit hitObj) {
        if (bigDrawerTri && GameObject.Find("BigDrawerCamera").GetComponent<Camera>().enabled)
        {
            if (hitObj.transform.tag.Equals("BigDrawer"))
            {
                GameObject.Find("CabinetAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("BigDrawer").transform.FindChild("TopBigDrawer").gameObject.SetActive(true);
            }
            else if (hitObj.transform.tag.Equals("Paper2"))
            {
                ItemDatabase.db.Add(hitObj.transform.gameObject.name);
                GameObject.Find("PaperAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("Paper2WindowBack").gameObject.GetComponent<Image>().enabled = true;
                GameObject.Find("Paper2Image").gameObject.GetComponent<RawImage>().enabled = true;

                GameObject.Find("PaperDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                GameObject.Find("Paper2").gameObject.SetActive(false);
            }
            else if (hitObj.transform.tag.Equals("TopBigDrawer"))
            {
                GameObject.Find("CabinetAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("TopBigDrawer").gameObject.SetActive(false);
            }
        }
        else
            bigDrawerTri = true;
    }

    void TableTri(RaycastHit hitObj) {
        if (tableTri && GameObject.Find("TableCamera").GetComponent<Camera>().enabled)
        {
            if (hitObj.transform.tag.Equals("Table"))
            {
                GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("TableDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
            }
            else if (hitObj.transform.tag.Equals("EpicItem1"))
            {
                ItemDatabase.db.Add(hitObj.transform.gameObject.name);
                GameObject.Find("DiaryAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("DiaryWindowBack").gameObject.GetComponent<Image>().enabled = true;
                 
                GameObject.Find("DiaryImage").gameObject.GetComponent<RawImage>().enabled = true;

                GameObject.Find("DiaryDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                GameObject.Find("Diary").gameObject.SetActive(false);
            }
        }
        else
            tableTri = true;
    }

    void BoxTri(RaycastHit hitObj) {
        if (boxTri && GameObject.Find("BoxCamera").GetComponent<Camera>().enabled)
        {
            if (hitObj.transform.tag.Equals("KeyBox"))
            {
                if (!GameObject.Find("bed1").transform.FindChild("Hammer").gameObject.activeSelf && hammerCount < 4)
                {
                    GameObject.Find("BreakBoxAudio").GetComponent<AudioSource>().Play();
                    Destroy(GameObject.Find("Box1"));
                    hammerCount = 4;
                }
                else {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    GameObject.Find("BoxDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                }
            }

            if (hitObj.transform.tag.Equals("Box2"))
            {
                if (!GameObject.Find("bed1").transform.FindChild("Hammer").gameObject.activeSelf && hammerCount < 4)
                {
                    GameObject.Find("BreakBoxAudio").GetComponent<AudioSource>().Play();
                    Destroy(GameObject.Find("Box2"));
                    hammerCount++;
                }
                else {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    GameObject.Find("BoxDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                }
            }

            if (hitObj.transform.tag.Equals("Box3"))
            {
                if (!GameObject.Find("bed1").transform.FindChild("Hammer").gameObject.activeSelf && hammerCount < 4)
                {
                    GameObject.Find("BreakBoxAudio").GetComponent<AudioSource>().Play();
                    Destroy(GameObject.Find("Box3"));
                    hammerCount++;
                }
                else {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    GameObject.Find("BoxDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                }
            }

            if (hitObj.transform.tag.Equals("Box4"))
            {
                if (!GameObject.Find("bed1").transform.FindChild("Hammer").gameObject.activeSelf && hammerCount < 4)
                {
                    GameObject.Find("BreakBoxAudio").GetComponent<AudioSource>().Play();
                    Destroy(GameObject.Find("Box4"));
                    hammerCount++;
                }
                else {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    GameObject.Find("BoxDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                }
            }

            if (hitObj.transform.tag.Equals("Key"))
            {
                ItemDatabase.db.Add(hitObj.transform.gameObject.name);
                GameObject.Find("KeyAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("KeyWindowBack").gameObject.GetComponent<Image>().enabled = true;
                GameObject.Find("KeyImage").gameObject.GetComponent<RawImage>().enabled = true;
                GameObject.Find("KeyDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                GameObject.Find("Key").gameObject.SetActive(false);
            }
        }
        else
            boxTri = true;
    }

    void HammerCount() {
        if (hammerCount == 4)
        {
            GameObject.Find("BrokenHammerAudio").GetComponent<AudioSource>().Play();
            GameObject.Find("BrokenHammerDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
            hammerCount = 5;
            ClickedSlot("Hammer");
        }
    }

    void ExitRoom1()
    {
        if (GameObject.Find("Button2").GetComponent<Renderer>().material.color == Color.magenta
            && GameObject.Find("Button4").GetComponent<Renderer>().material.color == Color.red
            && GameObject.Find("Button5").GetComponent<Renderer>().material.color == Color.magenta
            && GameObject.Find("Button7").GetComponent<Renderer>().material.color == Color.red
            && GameObject.Find("Button1").GetComponent<Renderer>().material.color == Color.white
            && GameObject.Find("Button3").GetComponent<Renderer>().material.color == Color.white
            && GameObject.Find("Button6").GetComponent<Renderer>().material.color == Color.white
            && GameObject.Find("Button8").GetComponent<Renderer>().material.color == Color.blue
            && GameObject.Find("Button9").GetComponent<Renderer>().material.color == Color.white
            && clear
        )
        {
            GameObject.Find("DoorOpenAudio").GetComponent<AudioSource>().Play();
            GameObject.Find("Keypad").GetComponentInChildren<Collider>().enabled = false;
            GameObject.Find("ExitDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
            GameObject.Find("Door").transform.FindChild("Door_Door1").gameObject.SetActive(false);
            clear = false;
            exit = true;
        }

        if (exit)
        {
            GameObject.Find("Exit").GetComponent<Collider>().enabled = true;
            exit = false;
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
                    GameObject.Find("SlotV" + i).GetComponent<Image>().sprite = GameObject.Find("SlotV" + (i+1)).GetComponent<Image>().sprite;
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