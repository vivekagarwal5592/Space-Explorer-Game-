using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;

	private CharacterController _charController;
	private GameObject portal;
	
	void Start() {
		_charController = GetComponent<CharacterController>();
		portal= GameObject.Find("portal");
	}
	
	void Update() {
		//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);

	//	transform.Translate(0, 0, speed * Time.deltaTime);

	//	transform.position += new Vector3(deltaX, 0, deltaZ);


	}

	void OnCollisionEnter(Collision col){

	}

	void OnTriggerEnter(Collider other) {
		Vector3 position = new Vector3(Random.Range(-98.0f, 98.0f), 0, Random.Range(-98.0f, 98.0f));
		transform.position = position;
	}
}
