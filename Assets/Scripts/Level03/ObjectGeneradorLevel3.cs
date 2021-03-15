using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGeneradorLevel3 : MonoBehaviour {

	public GameObject[] obj;
	public float minTime = 1f;
	public float maxTime = 2.0f;

	private GameObject selected;

	// Use this for initialization
	void Start () {
		Generator ();
	}
		
	void Generator() {
		int randoPosition = Random.Range (0, obj.Length);

		selected = obj [randoPosition];
		selected.SetActive (true);

		Invoke ("SetDisableSelected", 2f);
	}

	void SetDisableSelected() {
		selected.SetActive (false);
		Generator ();
	}
}
