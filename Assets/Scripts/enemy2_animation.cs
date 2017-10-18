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
		if(_animator.GetBool ("alive") && !(_animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle"))){
		distance = Vector3.Distance (player.transform.position, this.transform.position);
		_animator.SetFloat ("player_distance", distance);

	}


	}
}
