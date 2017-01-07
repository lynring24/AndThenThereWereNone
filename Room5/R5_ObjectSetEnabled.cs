/* to set the objects disable first at the scene so it could activate later on*/
using UnityEngine;
using System.Collections;

public class ObjectSetEnabled : MonoBehaviour {
	public void Start () {
		gameObject.SetActive (false);
	}
}
