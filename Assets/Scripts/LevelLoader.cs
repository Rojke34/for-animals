using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public Slider slider;
	public Button button;

	private bool isDone = false;
	private float count = 0.0f;

	void Start() {
		StartCoroutine (LoadAsynchronously (SceneManager.GetActiveScene ().buildIndex + 1));
	
		Invoke ("finished", 5f);
	}
		
	IEnumerator LoadAsynchronously(int sceneIndex) {
		while (!isDone) {
			count += 0.01f;
			float progress = Mathf.Clamp01 (count / 0.9f);
			slider.value = progress;
			Debug.Log ("end");

			yield return null;
		}
	}

	void finished() {
		isDone = true;
	}

	void Update() {
		Debug.Log (slider.value);
		if (slider.value >= 1) {
			slider.gameObject.SetActive (false);
			button.gameObject.SetActive (true);
		}
	}

	public void LoadLevel(){
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

}
