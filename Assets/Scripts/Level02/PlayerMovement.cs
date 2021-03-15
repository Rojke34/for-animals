using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody rb;

	private float xMin = -17f;
	private float xMax = 17f;

	public float forwardForce = 2000f;	// Variable that determines the forward force
	public float sidewaysForce = 0.05f;  // Variable that determines the sideways force

	private bool isButtonLeft  = false;
	private bool isButtonRight = false;

	private float rbPosition = 0f;

	void Update () {
		
		rbPosition = rb.position.x;

		if (rbPosition > xMin && rbPosition < xMax) {
			
			if (isButtonLeft) {
				if (rbPosition >= -16) {
					transform.Translate (sidewaysForce * 0.001f, 0, 0);
				}
			} 

			if (isButtonRight) {
				if (rbPosition <= 16) {
					transform.Translate (-sidewaysForce * 0.001f, 0, 0);
				}
			}

		} else {
			Debug.Log ("hereeee1");
		}
	}

	// Button Left
	public void ButtonLeftUp() {
		isButtonLeft = false;
	}

	public void ButtonLeftDown() {
		isButtonLeft = true;
	}

	//Button Right
	public void ButtonRightUp() {
		isButtonRight = false;
	}

	public void ButtonRightDown() {
		isButtonRight = true;
	}
}