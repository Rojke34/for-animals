using UnityEngine;

public class ObjectGenerator : MonoBehaviour {
	public GameObject[] obj;
	public float minTime = 2.5f;
	public float maxTime = 5.0f;

	// Use this for initialization
	void Start () {
		Generator ();
	}

	void Generator() {
		int randoPosition = Random.Range (0, obj.Length);
		var selected = obj [randoPosition];

		Instantiate (selected, transform.position, Quaternion.identity);

		Invoke("Generator", Random.Range(minTime, maxTime));
	}
}
