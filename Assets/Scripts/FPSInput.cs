using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public const float baseSpeed = 6.0f;
	public float speed = 6.0f;
	public float gravity = -9.8f;
	private AudioSource source;
	private CharacterController _charController;

	void Awake() {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	//	Messenger.AddListener("OnPlayerAttacked",OnPlayerAttacked );
	}
	void OnDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	//	Messenger.RemoveListener("OnPlayerAttacked",OnPlayerAttacked );
	}

	void Start() {
		_charController = GetComponent<CharacterController>();
		source = GetComponent<AudioSource>();
	}
	
	void Update() {
		//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		if (Input.GetKey(KeyCode.LeftShift)) {
		//	print ("inside if");
			deltaZ = Input.GetAxis("Vertical") * speed*2;
			 deltaX = Input.GetAxis ("Horizontal") * speed*2;
		} 
		//print (deltaZ);

		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		//movement = Vector3.ClampMagnitude(movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}

	private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
	}

	void OnTriggerEnter(Collider other) {

		//print ("collsion");
		if(other.gameObject.CompareTag("portal")){
			Vector3 position = new Vector3(Random.Range(-98.0f, 98.0f), 0, Random.Range(-98.0f, 98.0f));
			transform.position = position;
		}

		if(other.gameObject.CompareTag("food")){
			source.Play();
			Destroy(other.gameObject);
			Messenger.Broadcast ("onFoodCollected");
		}

		if(other.gameObject.CompareTag("collectible")){
			Destroy(other.gameObject);
			Messenger.Broadcast ("onCollectibleCollected");
		}

	}
		


}
