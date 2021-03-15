using UnityEngine;
using System.Collections.Generic;

public class Teleportation : MonoBehaviour {

	private GameObject gameObjectToTeleport;

	public GameObject cubeIndicator;

	GameObject[] gameObjects;

	RaycastHit hit;

	List<GameObject> objectToTelepor;
	List<Vector3> positionObject;

	private GameObject obj1;
	private GameObject obj2;

	private Vector3 vPosition;

	List<string> generators;

	void Start() {
		objectToTelepor = new List<GameObject> ();
		positionObject = new List<Vector3>();

		generators = new List<string>();
		generators.Add ("Kevin");
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (ray, out hit)) {
					gameObjectToTeleport = hit.collider.gameObject;
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				Debug.Log("Se levanto el click");

				if (gameObjectToTeleport.CompareTag("Can")) {
					Debug.Log("Es un objeto tipo caneca");
					//Busco el nombre sino esta lo agrego

					if(!generators.Contains(gameObjectToTeleport.name)){
						//Add el indicardor
						Instantiate (cubeIndicator, gameObjectToTeleport.transform.position, Quaternion.identity);

						AddNameToGenerators(gameObjectToTeleport.name);
						objectToTelepor.Add(gameObjectToTeleport);

						vPosition = new Vector3(gameObjectToTeleport.GetComponent<Rigidbody> ().position.x, gameObjectToTeleport.GetComponent<Rigidbody> ().position.y, gameObjectToTeleport.GetComponent<Rigidbody> ().position.z);
						positionObject.Add(vPosition);	
					}
				} else {
					Debug.Log("Pincho otro objeto");
				}

			if(objectToTelepor.Count == 2) {
				obj1 = objectToTelepor [0];
				obj2 = objectToTelepor [1];

				obj1.transform.position = positionObject[1];
				obj2.transform.position = positionObject[0];

				ClearAllLists();
				DestroyAllIndicators();
			}
		}

		#endif

		foreach (Touch touch in Input.touches) {

			switch (touch.phase) {

			case TouchPhase.Began:
				Ray ray = Camera.main.ScreenPointToRay (touch.position);

				if (Physics.SphereCast (ray, 0.5f, out hit)) {
					gameObjectToTeleport = hit.collider.gameObject;
				}
					
				break;

			case TouchPhase.Ended:
				if (gameObjectToTeleport.tag == "Can") {
					if(!generators.Contains(gameObjectToTeleport.name)){
						//Add el indicardor
						Instantiate (cubeIndicator, gameObjectToTeleport.transform.position, Quaternion.identity);

						AddNameToGenerators(gameObjectToTeleport.name);
						objectToTelepor.Add(gameObjectToTeleport);

						vPosition = new Vector3(gameObjectToTeleport.GetComponent<Rigidbody> ().position.x, gameObjectToTeleport.GetComponent<Rigidbody> ().position.y, gameObjectToTeleport.GetComponent<Rigidbody> ().position.z);
						positionObject.Add(vPosition);	
					}
				}

				break;
			}
		}

		if(objectToTelepor.Count == 2) {
			obj1 = objectToTelepor [0];
			obj2 = objectToTelepor [1];

			obj1.transform.position = positionObject[1];
			obj2.transform.position = positionObject[0];

			ClearAllLists();
			DestroyAllIndicators();
		}
	}
		
	void AddNameToGenerators(string name) {
		generators.Add (name);
	}

	void DestroyAllIndicators() {
		gameObjects = GameObject.FindGameObjectsWithTag ("Indicator");

		for(var i = 0 ; i < gameObjects.Length ; i ++) {
			Destroy(gameObjects[i], 0.5f);
		}
	}

	void ClearAllLists() {
		objectToTelepor.Clear();
		positionObject.Clear();
		generators.Clear();
	}
}
