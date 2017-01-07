using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectZoomOut : MonoBehaviour {
	public Camera  MainCamera,ObjectCamera;//메인 카메라와 오브젝트 카메라//UI 버튼들
	public void ZoomOut(){

        GameObject.Find("zoomSound").GetComponent<AudioSource>().Play();

        MainCamera.enabled = !MainCamera.enabled;//메인카메라 enabled
		ObjectCamera.enabled = !ObjectCamera.enabled;//disabled
		GameObject.Find ("CamLeft").GetComponent<Image> ().enabled = true;
		GameObject.Find ("CamRight").GetComponent<Image> ().enabled = true;
		//UI좌우버튼 활성화
		GameObject.Find ("ShelfBack").GetComponent<Image> ().enabled = false;
		GameObject.Find ("LightBack").GetComponent<Image> ().enabled = false;
		GameObject.Find ("MirrorBack").GetComponent<Image> ().enabled = false;
		GameObject.Find ("HangerBack").GetComponent<Image> ().enabled = false;
	
		GameObject.Find("ShelfCamera").GetComponent<AudioListener>().enabled=false;
		GameObject.Find("LightCamera").GetComponent<AudioListener>().enabled=false;
		GameObject.Find("HangerCamera").GetComponent<AudioListener>().enabled=false;
		GameObject.Find("MirrorCamera").GetComponent<AudioListener>().enabled=false;
		GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled=true;
		//UI back버튼 활성화
	}
}
