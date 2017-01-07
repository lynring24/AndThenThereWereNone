using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundPlay : MonoBehaviour {

    public void ClickButton() {
        GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
    }
}
