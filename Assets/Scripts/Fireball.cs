using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public float speed = 10.0f;
	private int damage = 1;
	private System.DateTime object_creation_time ;
		
	void Start(){
	//	print ("object instatiated");
		object_creation_time = System.DateTime.Now;
	}

	void Update() {
		transform.Translate(0, 0, speed * Time.deltaTime*2);
		//print (object_creation_time);
		System.TimeSpan travelTime = object_creation_time - System.DateTime.Now;  
		if (travelTime.TotalSeconds < -2f) {
			Destroy(this.gameObject);
		} 
		//if(object_creation_time - System.DateTime.Now>=5f){
	//		print ("destroy");
		//	print (object_creation_time -  Time.deltaTime);
	//	}

	}

	void OnTriggerEnter(Collider other) {
		
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
		//	print("hit");
			player.Hurt(damage);
		}

		enemy2 zombie =  other.GetComponent<enemy2>();
		boss boss = other.GetComponent<boss>();
		WanderingAI reptile = other.GetComponent<WanderingAI>();
		if (zombie != null) {
			ReactiveTarget target = zombie.GetComponent<ReactiveTarget>();
       	print("child found");

       	zombie.transform.Find("blood").gameObject.active = true;

           // the code here is called 
           // for each child named Bone
       
		
		target.ReactToHit();
	}
		else if(reptile != null){
			print("reptile hit");
			ReactiveTarget target = reptile.GetComponent<ReactiveTarget>();
			target.ReactToHit();
		}
		else if(boss !=null){
			boss.hurt(10);
		}

		Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision col){
	//	print ("collsion");
		Destroy(this.gameObject);
	}
}
