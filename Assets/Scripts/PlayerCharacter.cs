using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
	private float _health;
	public Text health;

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
		health.text = "Health: " + _health.ToString();
	}


}
