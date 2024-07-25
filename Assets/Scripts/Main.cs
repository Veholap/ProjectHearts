using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public Slider loadBar;

    void Start() {
		Debug.Log("MAIN START");
		StartCoroutine(LoadYourAsyncScene());
	}

    void Update() {

    }

	IEnumerator LoadYourAsyncScene() {
		// The Application loads the Scene in the background as the current Scene runs.
		// This is particularly good for creating loading screens.
		// You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
		// a sceneBuildIndex of 1 as shown in Build Settings.

		yield return new WaitForSeconds(0.5f);

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");

		// Wait until the asynchronous scene fully loads
		while (!asyncLoad.isDone) {
			loadBar.value = asyncLoad.progress;
			Debug.Log(asyncLoad.progress + "%");
			yield return null;
		}
	}

}
