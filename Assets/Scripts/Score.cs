using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;

	private int count;

	void Start() {
		count = 0;
	}

	// Update is called once per frame
	void Update () {
		count += 1;

		scoreText.text = count.ToString ();
	}
}
