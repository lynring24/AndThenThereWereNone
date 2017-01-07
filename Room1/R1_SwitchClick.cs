//방안의 main 조명이 enabled/disabled일 때
//스크립트는 조명 오브젝트에 붙이면 된다.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Room1_SwitchClick : MonoBehaviour {
	public Camera MainCamera;//메인 카메라
	public GameObject Door, Keypad;//불이 꺼진 상태일 경우 비활성화할 오브젝트 변수
	public GameObject CamLeft, CamRight;

    // Use this for initialization
    void Start () {
        GetComponent<Light>().enabled= false;//라이트 오브젝트: disable
        Door.gameObject.GetComponent<Collider>().enabled = false;
        Keypad.gameObject.SetActive(false);
        //오브젝트를 비활성화->충돌요소를 제거하여 불이 꺼진 상태로 zoom in이 되지 않게 함
        CamLeft.gameObject.GetComponent<Image>().enabled = false;
        CamRight.gameObject.GetComponent<Image>().enabled = false;
        //UI를 비활성화->불이 꺼진 상태로 카메라가 돌아가는 불상사 방지용       
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {//마우스 버튼 누르면
			Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
			//메인 카메라에서 마우스 포지션 받아서 ray에 assign
			switchOnOff (ray);
		}

	}

	void switchOnOff(Ray ray){

        RaycastHit hitObj;
		if(Physics.Raycast(ray, out hitObj, Mathf.Infinity)){//시작지점, 방향, 길이
            if (hitObj.collider != null && hitObj.transform.tag.Equals("Switch")) {
                if (GetComponent<Light>().enabled == false)
                {
                    GameObject.Find("SwitchAudio").GetComponent<AudioSource>().Play();
                    GetComponent<Light>().enabled = true;

                    GameObject.Find("Door_Door1").GetComponent<Collider>().enabled = true;
                    GameObject.Find("KeypadObj").transform.FindChild("Keypad").gameObject.SetActive(true);
                    GameObject.Find("CamLeft").GetComponent<Image>().enabled = true;
                    GameObject.Find("CamRight").GetComponent<Image>().enabled = true;
                    //불켜지면 다같이 활성화
                }
                else {
                    GameObject.Find("SwitchDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = true;
                }
            }
		}
	}
}