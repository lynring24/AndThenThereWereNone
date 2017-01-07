using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneFlow : MonoBehaviour {
	public void LoadGame()
	{
		SceneManager.LoadScene (1);
	}
}