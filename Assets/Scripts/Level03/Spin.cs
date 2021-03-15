﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public float speed = 20f;

	void Update () {
		transform.Rotate (new Vector3(0, speed * Time.deltaTime, 0));	
	}
}