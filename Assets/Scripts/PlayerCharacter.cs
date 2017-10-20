using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
	private float _health;
	public Text health;
	public Text game_over;


	void Start() {
		GameObject lightGameObject = new GameObject("The Light");
		Light lightComp = lightGameObject.AddComponent<Light>();
		lightComp.color = Color.blue;
		lightGameObject.transform.position = new Vector3(5, 5, 5);

		_health = 100.0f;
		health.text = "Health: " + _health.ToString();

	}

	public void Hurt(float damage) {
		_health -= damage;
		//Debug.Log("Health: " + _health);
	//	Debug.Log("player being attacked");

		if(_health <=0f){
			_health = 0f;
			game_over.text = "Game Over";
			health.text = "Health: " + 0;
			//Time.timeScale = 0; 
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Application.LoadLevel ("scenes/game_over");
		}
			
	//		


		health.text = "Health: " + _health.ToString();
	}

	public void food_eaten(){

		if(_health <100){
			_health += 5;
			if(_health >100){
				_health = 100;
			}
		}
		health.text = "Health: " + _health.ToString();


	}


	void OnControllerColliderHit(ControllerColliderHit hit) {
		//_contact = hit;
		float pushForce = 3;
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body != null && !body.isKinematic) {
			body.velocity= hit.moveDirection* pushForce;
		}
	}


}
