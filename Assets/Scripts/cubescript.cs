﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubescript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (0.01f,0,0);

		if (Input.GetMouseButtonDown(0)){




			Destroy(this);
		}
		
	}
}