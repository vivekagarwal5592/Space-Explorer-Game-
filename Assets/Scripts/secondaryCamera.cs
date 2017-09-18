﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondaryCamera : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;

	}

	void Update(){

		if (Input.GetKeyDown ("y")) {
			print ("A clicked");
		}

	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;

	}
}
