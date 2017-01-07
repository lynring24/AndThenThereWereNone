using UnityEngine;
using System.Collections;

public class CameraMove_5 : MonoBehaviour {

	public void CameraRotate(GameObject bttn){ // bttn = button 
        if (bttn.tag == "CAMRIGHT")
        { // 버튼의 태그를 비해서 오른쪽인면, 카메라를 오른쪽으로 회전
            transform.Rotate(Vector3.up, 90); // transform.Rotate()의 벡터 매변수의 축은 z,x,y 순이라서 Vector3.up을 사용해야합니다.
            GameObject.Find("zoomSound").GetComponent<AudioSource>().Play();
        }
        else if (bttn.tag == "CAMLEFT")
        {
            transform.Rotate(Vector3.down, 90);
            GameObject.Find("zoomSound").GetComponent<AudioSource>().Play();
        }
	}
}