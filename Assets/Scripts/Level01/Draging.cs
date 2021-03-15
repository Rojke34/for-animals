using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draging : MonoBehaviour {

	public GameObject gameObjectToDrag;

	public Vector3 gameObjectCenter;
	public Vector3 touchPosition;
	public Vector3 offset;
	public Vector3 newGameObjectCenter;

	RaycastHit hit;

	public bool dragginMode = false;

	// Update is called once per frame
	void Update () {

		#if UNITY_EDITOR
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (ray, out hit)) {
					gameObjectToDrag = hit.collider.gameObject;
					gameObjectCenter = gameObjectToDrag.transform.position;
					touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					offset = touchPosition - gameObjectCenter;
					dragginMode = true;
				}

			}

			if (Input.GetMouseButton (0)) {
				if (dragginMode) {
					touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					newGameObjectCenter = touchPosition - offset;
					
					if(gameObjectToDrag != null) {
						gameObjectToDrag.transform.position = new Vector3 (newGameObjectCenter.x, newGameObjectCenter.y, gameObjectCenter.z);
					}
					
				}
			}


			if (Input.GetMouseButtonUp (0)) {
				dragginMode = false;
			}
		#endif


		foreach (Touch touch in Input.touches) {
			
			switch (touch.phase) {

			case TouchPhase.Began:
				Ray ray = Camera.main.ScreenPointToRay (touch.position);

				if (Physics.SphereCast (ray, 0.5f, out hit)) {
					gameObjectToDrag = hit.collider.gameObject;
					gameObjectToDrag.GetComponent<Rigidbody> ().useGravity = false;
					gameObjectCenter = gameObjectToDrag.transform.position;
					touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					offset = touchPosition - gameObjectCenter;
					dragginMode = true;	
				}


				break;

			case TouchPhase.Moved: 
				if (dragginMode) {
					touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					newGameObjectCenter = touchPosition - offset;
					gameObjectToDrag.transform.position = new Vector3 (newGameObjectCenter.x, newGameObjectCenter.y, gameObjectCenter.z);
				}

				break;

			case TouchPhase.Ended:
				dragginMode = false;
				gameObjectToDrag.GetComponent<Rigidbody> ().useGravity = true;
				break;
			}
		
		}



	}
}
