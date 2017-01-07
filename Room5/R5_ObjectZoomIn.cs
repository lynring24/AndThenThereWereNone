using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectZoomIn : MonoBehaviour {
	public Camera ShelfCamera;
	public Camera LightCamera;// light generator camera
	public Camera MirrorCamera;
	public Camera HangerCamera;
	public Camera MainCamera;//for get mouse click
	private Camera MainCameraComponent;//for getting Component, so select same object with MainCamera
	public AudioSource bedSound,clickSound;
	public GameObject CamLeft, CamRight;//if you zoon in, then Left and Right button will be disabled

	// Use this for initialization
	void Start () {
        ItemDatabase.itemCount = 0;
        ItemDatabase.slotCount = 0;

        GameObject.Find("Exit").GetComponent<Collider>().enabled = false;
        GameObject.Find("Loading").GetComponent<Image>().enabled = false;
        GameObject.Find("ToBeContinue").GetComponent<Image>().enabled = false;

        GameObject.Find ("ShelfBack").GetComponent<Image> ().enabled = false;
		GameObject.Find ("LightBack").GetComponent<Image> ().enabled = false;
		GameObject.Find ("MirrorBack").GetComponent<Image> ().enabled = false;
		GameObject.Find ("HangerBack").GetComponent<Image> ().enabled = false;
		MainCameraComponent = MainCamera;
		ShelfCamera.GetComponent<Camera>().enabled = false;//object camera is disabled at very first;
		LightCamera.GetComponent<Camera>().enabled = false;
		MirrorCamera.GetComponent<Camera>().enabled = false;
		HangerCamera.GetComponent<Camera>().enabled = false;
		MainCamera.GetComponent<Camera>().enabled = true;//main camera is enabled at very first
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (MainCamera.enabled) {//if main camera is enabled and object camera is disabled
				Ray ray = MainCameraComponent.ScreenPointToRay (Input.mousePosition);
				zoomIn (ray);
			}
		}
	}

	void zoomIn(Ray ray){
		RaycastHit hitObj;

		if (Physics.Raycast (ray, out hitObj, Mathf.Infinity)) {

            if (hitObj.transform.tag.Equals("SHELF")) {
                GameObject.Find("shelfTri").gameObject.GetComponent<TextBoxTrigger_5>().enabled = true;
            }

            if (hitObj.transform.tag.Equals("EXIT")&& ObjectTrigger.key==true)
            {
                GameObject.Find("doorSound").GetComponent<AudioSource>().Play();
                GameObject.Find("OUTGO").transform.FindChild("DOOROUT").gameObject.gameObject.SetActive(false);
                ClickedSlot("Key");
                GameObject.Find("Exit").GetComponent<Collider>().enabled = true;
            }

            if (hitObj.transform.tag.Equals("Exit"))
            {
                GameObject.Find("FootStepAudio").GetComponent<AudioSource>().Play();
                GameObject.Find("Loading").GetComponent<Image>().enabled = true;
                GameObject.Find("ToBeContinue").GetComponent<Image>().enabled = true;
                SceneManager.LoadScene(0);
            }

            if (hitObj.collider != null&&MainCamera.enabled) {
				if (hitObj.transform.tag.Equals ("GUN") || hitObj.transform.tag.Equals("HAMMER")) {//메인카메라가 화면을 비출때, Door와 충돌이 발생하면 Zoom In
                    GameObject.Find("clickSound").GetComponent<AudioSource>().Play();
                    MainCamera.enabled = !MainCamera.enabled;//메인카메라 끔
					ShelfCamera.enabled = !ShelfCamera.enabled;//오브젝트 카메라 켬
					CamLeft.GetComponent<Image> ().enabled = false;
					CamRight.GetComponent<Image> ().enabled = false;//좌우 UI버튼 비활성화
					GameObject.Find ("ShelfBack").GetComponent<Image> ().enabled = true;//Back 버튼 활성화
					GameObject.Find("ShelfCamera").GetComponent<AudioListener>().enabled=true;
					GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled=false;
					}
				else if(hitObj.transform.tag.Equals("LAMPL")||hitObj.transform.tag.Equals("LAMPR")){
                    GameObject.Find("clickSound").GetComponent<AudioSource>().Play();
                    MainCamera.enabled = !MainCamera.enabled;
					LightCamera.enabled = !LightCamera.enabled;
					CamLeft.GetComponent<Image> ().enabled = false;
					CamRight.GetComponent<Image> ().enabled = false;
					bedSound.Play ();
					GameObject.Find ("lampTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = true;// 대화창
					GameObject.Find("LightBack").GetComponent<Image> ().enabled = true;
					GameObject.Find("LightCamera").GetComponent<AudioListener>().enabled=true;
					GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled=false;
				}
				else if(hitObj.transform.tag.Equals("CLOCK")){
                    GameObject.Find("clickSound").GetComponent<AudioSource>().Play();
                    GameObject.Find ("clockTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = true;
					MainCamera.enabled = !MainCamera.enabled;
					MirrorCamera.enabled = !MirrorCamera.enabled;
					CamLeft.GetComponent<Image> ().enabled = false;
					CamRight.GetComponent<Image> ().enabled = false;

					GameObject.Find ("MirrorBack").GetComponent<Image> ().enabled = true;
					GameObject.Find("MirrorCamera").GetComponent<AudioListener>().enabled=true;
					GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled=false;
				}else if(hitObj.transform.tag.Equals("CLOTH")){
                    GameObject.Find("clickSound").GetComponent<AudioSource>().Play();
                    MainCamera.enabled = !MainCamera.enabled;
					HangerCamera.enabled = !HangerCamera.enabled;
					CamLeft.GetComponent<Image> ().enabled = false;
					CamRight.GetComponent<Image> ().enabled = false;

					GameObject.Find ("HangerBack").GetComponent<Image> ().enabled = true;
					GameObject.Find("HangerCamera").GetComponent<AudioListener>().enabled=true;
					GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled=false;
				}


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

