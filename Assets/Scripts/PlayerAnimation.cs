using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator _animator;
	void Start () {
		_animator = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.LeftShift)) {}

		if(Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) ||
			Input.GetKey(KeyCode.RightArrow)){
			start_walking();
		}
		else{
			stop_walking();
		}
		if(Input.GetKey(KeyCode.LeftShift)) {
			start_running();
		}
		else {
			stop_running();
		}

		if(Input.GetKeyDown(KeyCode.Space)){
		//	start_jump();
		}
		else{
		//	stop_jump();
		}
	}

	public void start_walking(){
		_animator.SetBool ("walk",true);
		_animator.SetBool ("idle",false);
	}

	public void stop_walking(){
		_animator.SetBool ("walk",false);
		_animator.SetBool ("idle",true);
	}

	public void start_running(){
		//_animator.SetBool ("walk",false);
		
		_animator.SetBool ("run",true);
	}

	public void stop_running(){
	//	_animator.SetBool ("walk",true);
		
		_animator.SetBool ("run",false);

	}

	public void start_jump(){
		_animator.SetBool ("jump",true);
	}
	public void stop_jump(){
		_animator.SetBool ("jump",false);
	}

}
