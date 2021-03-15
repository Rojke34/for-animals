using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public TimeManager timeManager;

	bool gameHasEnded = false;
	bool gameHasCompleted = false;
	public float restarDelay = 1f;

	public GameObject completeLevelUI;
	public GameObject gameOverLevelUI;
	public GameObject dontLetsGoUI;

	public Slider slider;
	private float points = 0.0f;

	public GameObject panel;

	public GameObject[] lives;

	private int numberOfLives = 4;

	private float numberOfElementsToWin = 10f;

	public void CompleteLevel (){
		if (gameHasCompleted == false) {
			gameHasCompleted = true;
			completeLevelUI.SetActive (true);
		}
	}

	public void EndGame() {
		if (gameHasEnded == false) {
			gameHasEnded = true;
			gameOverLevelUI.SetActive (true);
		}
	}
		
	public void PointUp() {
		if (points <= 1) {
			
			points += 1 / numberOfElementsToWin;

			UpdateSlider ();

		}
	}

	public void PointDown() {
		var minimunElement = 1 / numberOfElementsToWin;

		if (points >= minimunElement) {
			points -= minimunElement;
			UpdateSlider ();
			RemoveLive ();
		}
	}

	void UpdateSlider() {
		slider.value = points;
	
		if (slider.value >= 1) {
			CompleteLevel ();
		}
	}
		
	public void RemoveLive() {
		numberOfLives -= 1;

		if (numberOfLives % 2 == 0) {
			dontLetsGoUI.SetActive (true);
			Invoke ("HideDontLetsGo", 2f);
		}

		if (numberOfLives > 0) {
			lives [numberOfLives].SetActive (false);
		} else {
			EndGame ();
		}
	}

	void HideDontLetsGo() {
		dontLetsGoUI.SetActive (false);
	}

	public void Restar() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}


	private bool isSlowActive = false;

	public void ActiveSlow() {
		Debug.Log ("Active button for slow");

		if (isSlowActive == false) {
			isSlowActive = true;

			panel.SetActive (true);
			timeManager.DoSlowmotion ();

			Invoke ("DisableSlow", 5f);
		}
	}

	private void DisableSlow() {
		isSlowActive = false;
		panel.SetActive (false);
	}

}
