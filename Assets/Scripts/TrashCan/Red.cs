using UnityEngine;

public class Red : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Red")) {
			
			Destroy(other.gameObject);
		}
	}
}
