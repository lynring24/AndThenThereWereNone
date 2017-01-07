using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Loading : MonoBehaviour {

    void Start() {
        GameObject.Find("Loading").GetComponent<Image>().enabled = false;
        GameObject.Find("LoadingImage").GetComponent<Image>().enabled = false;
    }

    public void Load() {
        GameObject.Find("Loading").GetComponent<Image>().enabled = true;
        GameObject.Find("LoadingImage").GetComponent<Image>().enabled = true;
    }
}
