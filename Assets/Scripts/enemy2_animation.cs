using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2_animation : MonoBehaviour {

	private Animator _animator;
	private float _speed=3.0f;
	float distance = 0;
	private GameObject player;
	public float obstacleRange = 5;
	void Start () {
		_animator = GetComponent<Animator>();
		player = GameObject.Find ("player1");
	}
	
	// Update is called once per frame
	void Update () {

		//	print (_animator.GetFloat("player_distance"));
		//	_animator.SetFloat("Speed", _speed);
		if(_animator.GetBool ("alive") && !(_animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle"))){
		distance = Vector3.Distance (player.transform.position, this.transform.position);
		_animator.SetFloat ("player_distance", distance);

		if (distance > 3 && !(_animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) ) {
	//		transform.Translate (0, 0, _speed * Time.deltaTime);
		} else {
		//	transform.Translate (0, 0, 0);
		}

//		if (distance < 25) {
//			Vector3 movement = new Vector3 (player.transform.eulerAngles.x, player.transform.eulerAngles.y - 180, player.transform.eulerAngles.z);
//			transform.eulerAngles = movement;
//
//		}

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast (ray, 0.75f, out hit)) {

		//	GameObject hitObject = hit.transform.gameObject;
		//	if (hit.distance < obstacleRange) {
		//		float angle = Random.Range (-110, 110);
		//		transform.Rotate (0, angle, 0);
		//	}

		}
	}


	}
}
