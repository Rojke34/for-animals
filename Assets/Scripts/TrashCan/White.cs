using UnityEngine;

public class White : MonoBehaviour {


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("White")) {

			Destroy(other.gameObject);
		}
	}

}
