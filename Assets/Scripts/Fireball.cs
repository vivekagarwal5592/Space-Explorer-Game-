using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public float speed = 10.0f;
	private int damage = 1;
	private System.DateTime object_creation_time ;
		
	void Start(){
		print ("object instatiated");
		object_creation_time = System.DateTime.Now;
	}

	void Update() {
		transform.Translate(0, 0, speed * Time.deltaTime*2);
		//print (object_creation_time);
		System.TimeSpan travelTime = object_creation_time - System.DateTime.Now;  
		if (travelTime.TotalSeconds < -5f) {
			Destroy(this.gameObject);
		} 
		//if(object_creation_time - System.DateTime.Now>=5f){
	//		print ("destroy");
		//	print (object_creation_time -  Time.deltaTime);
	//	}

	}

	void OnTriggerEnter(Collider other) {
		//print ("trigger with something");
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
			player.Hurt(damage);
		}
		Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision col){
		//print ("collision with something");
	}
}
