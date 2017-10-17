using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		print ("inside introcanvas");
		if(transform.position.y<=270f){
			Vector3 position = new Vector3 (0,.4f,0f);
			transform.position += position;
		}



	}
}
