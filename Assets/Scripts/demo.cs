using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : MonoBehaviour {

	public float pokeForce;
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			if (hit.rigidbody != null)
				hit.rigidbody.AddForceAtPosition(ray.direction * pokeForce, hit.point);


		}
	}
}
