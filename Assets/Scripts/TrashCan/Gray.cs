using UnityEngine;

public class Gray : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Gray")) {
			Destroy(other.gameObject);
		}
	}
		
}
