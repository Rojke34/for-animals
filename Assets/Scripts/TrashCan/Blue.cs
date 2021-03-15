using UnityEngine;

public class Blue : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Indicator")) {
			return;
		}

		if (other.gameObject.CompareTag ("Blue")) {
			Destroy (other.gameObject);

			FindObjectOfType<GameManager> ().PointUp ();
		} else {
			FindObjectOfType<GameManager> ().RemoveLive ();
		}
	}
}
