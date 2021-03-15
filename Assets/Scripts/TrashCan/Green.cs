using UnityEngine;

public class Green : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Green")) {
			Destroy(other.gameObject);
		}
	}
}
