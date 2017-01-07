using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Room1_ObjectZoomOut : MonoBehaviour {
	
	public Camera MainCamera, ObjectCamera;//메인 카메라와 오브젝트 카메라//UI 버튼들

	public void ZoomOut(){
		MainCamera.enabled = true;//메인카메라 enabled
		ObjectCamera.enabled = false;//disabled

        GameObject.Find("ZoomAudio").GetComponent<AudioSource>().Play();

		//AudioListener Control
		GameObject.Find("Main Camera").GetComponent<AudioListener> ().enabled = true;
		GameObject.Find("DoorCamera").GetComponent<AudioListener> ().enabled = false;
		GameObject.Find("KeypadCamera").GetComponent<AudioListener> ().enabled = false;
		GameObject.Find("BedCamera").GetComponent<AudioListener> ().enabled = false;
		GameObject.Find("BigDrawerCamera").GetComponent<AudioListener> ().enabled = false;
		GameObject.Find("TableCamera").GetComponent<AudioListener> ().enabled = false;
		GameObject.Find("BoxCamera").GetComponent<AudioListener> ().enabled = false;

        GameObject.Find("CamLeft").GetComponent<Image>().enabled = true;
        GameObject.Find("CamRight").GetComponent<Image>().enabled = true;
        //UI좌우버튼 활성화

        GameObject.Find("DoorBack").GetComponent<Image>().enabled = false;
        GameObject.Find ("KeypadBack").GetComponent<Image>().enabled = false;
        GameObject.Find ("BedBack").GetComponent<Image>().enabled = false;
        GameObject.Find ("BigDrawerBack").GetComponent<Image>().enabled = false;
        GameObject.Find ("TableBack").GetComponent<Image>().enabled = false;
        GameObject.Find ("BoxBack").GetComponent<Image>().enabled = false;
        //UI back버튼 활성화
    }

}
