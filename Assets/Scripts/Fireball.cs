using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public float speed = 10.0f;
	public int damage = 1;

	void Update() {
		
		transform.Translate(0, 0, speed * Time.deltaTime*2);
	}

	void OnTriggerEnter(Collider other) {
		//print ("trigger with something");
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
		//	print ("collision with player");
			player.Hurt(damage);
		}
		Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision col){
		//print ("collision with something");
	}
}
