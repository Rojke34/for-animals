using UnityEngine;

public class Destructor : MonoBehaviour {

	private int count = 0;

	void OnTriggerExit (Collider other) {
		count += 1;
		Debug.Log ("Object Destroyed : " + count.ToString());

		Destroy(other.gameObject);



		FindObjectOfType<GameManager> ().RemoveLive ();
	}
}
