using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room1_ObjectZoomIn : MonoBehaviour {
	public Camera DoorCamera;
	public Camera KeypadCamera;
	public Camera BedCamera;
	public Camera BigDrawerCamera;
	public Camera TableCamera;
	public Camera BoxCamera;

	public Camera MainCamera;
	private Camera MainCameraComponent;
	public GameObject CamLeft, CamRight;

	void Start () {

		MainCameraComponent = MainCamera;

        GameObject.Find("DoorBack").GetComponent<Image>().enabled = false;
		GameObject.Find("KeypadBack").GetComponent<Image>().enabled = false;
        GameObject.Find("BedBack").GetComponent<Image>().enabled = false;
        GameObject.Find("BigDrawerBack").GetComponent<Image>().enabled = false;
        GameObject.Find("TableBack").GetComponent<Image>().enabled = false;
        GameObject.Find("BoxBack").GetComponent<Image>().enabled = false;

        DoorCamera.GetComponent<Camera>().enabled = false;
		KeypadCamera.GetComponent<Camera>().enabled = false;
		BedCamera.GetComponent<Camera>().enabled = false;
		BigDrawerCamera.GetComponent<Camera>().enabled = false;
		TableCamera.GetComponent<Camera> ().enabled = false;
		BoxCamera.GetComponent<Camera> ().enabled = false;

		//add AudioListener control

		MainCamera.GetComponent<Camera> ().enabled = true;
		MainCamera.GetComponent<AudioListener> ().enabled = true;

		GameObject.Find("TopDrawer").gameObject.SetActive (false);
		GameObject.Find("TopBigDrawer").gameObject.SetActive (false);

        GameObject.Find("Exit").GetComponent<Collider>().enabled = false;

        GameObject.Find("Loading").GetComponent<Image>().enabled = false;
        GameObject.Find("LoadingImage").GetComponent<Image>().enabled = false;
    }
		
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (MainCamera.enabled) {
				Ray ray = MainCameraComponent.ScreenPointToRay (Input.mousePosition);
				zoomIn (ray);
			}
		}
	}

	void zoomIn(Ray ray){
		RaycastHit hitObj;

		if (Physics.Raycast (ray, out hitObj, Mathf.Infinity)) {
		
			if (hitObj.collider != null && MainCamera.enabled) {

                //0.Exit
                if (hitObj.transform.tag.Equals("Exit"))
                {
                    GameObject.Find("FootStepAudio").GetComponent<AudioSource>().Play();
                    GameObject.Find("Loading").GetComponent<Image>().enabled = true;
                    GameObject.Find("LoadingImage").GetComponent<Image>().enabled = true;
                    SceneManager.LoadScene(2);
                }

                //1. Door
                if (hitObj.transform.tag.Equals ("Door")) {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    MainCamera.enabled = !MainCamera.enabled;
					DoorCamera.enabled = !DoorCamera.enabled;
                    GameObject.Find("DoorBack").GetComponent<Image>().enabled = true;
                    CamLeft.GetComponent<Image>().enabled = false;
					CamRight.GetComponent<Image>().enabled = false;
                    GameObject.Find("Main Camera").GetComponent<AudioListener> ().enabled = false;
					GameObject.Find("DoorCamera").GetComponent<AudioListener> ().enabled = true;
				} 

				//2. Keypad
				if (hitObj.transform.tag.Equals ("Keypad") ||
				    hitObj.transform.tag.Equals ("Button1") ||
				    hitObj.transform.tag.Equals ("Button2") ||
				    hitObj.transform.tag.Equals ("Button3") ||
				    hitObj.transform.tag.Equals ("Button4") ||
				    hitObj.transform.tag.Equals ("Button5") ||
				    hitObj.transform.tag.Equals ("Button6") ||
				    hitObj.transform.tag.Equals ("Button7") ||
				    hitObj.transform.tag.Equals ("Button8") ||
				    hitObj.transform.tag.Equals ("Button9")) {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    MainCamera.enabled = !MainCamera.enabled;
					KeypadCamera.enabled = !KeypadCamera.enabled;
					GameObject.Find ("KeypadBack").GetComponent<Image>().enabled = true;
                    CamLeft.GetComponent<Image>().enabled = false;
                    CamRight.GetComponent<Image>().enabled = false;
                    GameObject.Find("Main Camera").GetComponent<AudioListener> ().enabled = false;
					GameObject.Find("KeypadCamera").GetComponent<AudioListener> ().enabled = true;
				} 

				//3. Bed1~2 + Drawer
				if (hitObj.transform.tag.Equals ("Bed1") ||
				    hitObj.transform.tag.Equals ("Bed2") ||
				    hitObj.transform.tag.Equals ("Drawer")||
                    hitObj.transform.tag.Equals("TopDrawer")) {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    MainCamera.enabled = !MainCamera.enabled;
					BedCamera.enabled = !BedCamera.enabled;
					GameObject.Find("BedBack").GetComponent<Image>().enabled = true;
                    CamLeft.GetComponent<Image>().enabled = false;
                    CamRight.GetComponent<Image>().enabled = false;
                    GameObject.Find("Main Camera").GetComponent<AudioListener> ().enabled = false;
					GameObject.Find("BedCamera").GetComponent<AudioListener> ().enabled = true;
				} 
					
				//4. BigDrawer
				if (hitObj.transform.tag.Equals ("BigDrawer")|| hitObj.transform.tag.Equals("TopBigDrawer")) {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    MainCamera.enabled = !MainCamera.enabled;
					BigDrawerCamera.enabled = !BigDrawerCamera.enabled;
					GameObject.Find ("BigDrawerBack").GetComponent<Image>().enabled = true;
                    CamLeft.GetComponent<Image>().enabled = false;
                    CamRight.GetComponent<Image>().enabled = false;
                    GameObject.Find("Main Camera").GetComponent<AudioListener> ().enabled = false;
					GameObject.Find("BigDrawerCamera").GetComponent<AudioListener> ().enabled = true;
				}

				//5. Table + EpicItem1(diary)
				if(hitObj.transform.tag.Equals("Table")||
					hitObj.transform.tag.Equals("EpicItem1")){
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    MainCamera.enabled = !MainCamera.enabled;
					TableCamera.enabled = !TableCamera.enabled;
					GameObject.Find ("TableBack").GetComponent<Image>().enabled = true;
                    CamLeft.GetComponent<Image>().enabled = false;
                    CamRight.GetComponent<Image>().enabled = false;
                    GameObject.Find("Main Camera").GetComponent<AudioListener> ().enabled = false;
					GameObject.Find("TableCamera").GetComponent<AudioListener> ().enabled = true;
				}

				//6. Box 1~4 
				if(hitObj.transform.tag.Equals("KeyBox")||
					hitObj.transform.tag.Equals("Box2")||
					hitObj.transform.tag.Equals("Box3")||
					hitObj.transform.tag.Equals("Box4")||
                    hitObj.transform.tag.Equals("Key"))
                {
                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
                    MainCamera.enabled = !MainCamera.enabled;
					BoxCamera.enabled = !BoxCamera.enabled;
					GameObject.Find("BoxBack").GetComponent<Image>().enabled = true;
                    CamLeft.GetComponent<Image>().enabled = false;
                    CamRight.GetComponent<Image>().enabled = false;
                    GameObject.Find("Main Camera").GetComponent<AudioListener> ().enabled = false;
					GameObject.Find("BoxCamera").GetComponent<AudioListener> ().enabled = true;
				}

                //7. Window Trigger

                if (hitObj.transform.tag.Equals("Window"))
                {
                    GameObject.Find("WindowAudio").GetComponent<AudioSource>().Play();
                    GameObject.Find("WindowDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                }
            }
		}
	}
}