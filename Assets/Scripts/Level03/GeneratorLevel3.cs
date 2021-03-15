using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLevel3 : MonoBehaviour {
	public GameObject[] obj;

	public void Generate() {
		int randoPosition = Random.Range (0, obj.Length);
		var selected = obj [randoPosition];

		Instantiate (selected, transform.position, Quaternion.identity);
	}
		
	void OnEnable() {
		Debug.Log("PrintOnEnable: script was enabled");
		Generate ();
	}		
}