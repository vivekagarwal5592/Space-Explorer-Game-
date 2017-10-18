using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour {

	public float speed = 3.0f;
	public float obstacleRange = 5;
	private GameObject player;
	private PlayerCharacter playercharacter;
	private AudioSource[] swordSound;
	private bool _alive;

	void Start() {
		swordSound = GetComponents<AudioSource>();
		_alive = true;
		player = GameObject.Find ("player1");
	}

	void Update() {
		if (_alive) {
			if(Vector3.Distance(player.transform.position,transform.position) >25) {
			//	transform.LookAt(player.transform);
				transform.Translate (0, 0, speed * Time.deltaTime);
			
			}
			else if (Vector3.Distance (player.transform.position,transform.position) > 3
			//	&& 
				//Vector3.Distance (player.transform.position, this.transform.position) < 25
			) {
				//Vector3 movement =  new Vector3 (player.transform.eulerAngles.x,player.transform.eulerAngles.y-180 ,player.transform.eulerAngles.z);
				//transform.eulerAngles = movement;
			//	print ("in lookat");
				//transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
			transform.LookAt(player.transform);
				transform.Translate (0, 0, speed * Time.deltaTime);
			} 

			else{
		//		print ("in lookat2");
			//	transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
					transform.LookAt (player.transform);
				}

				//StartCoroutine (Attack());
			}


			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray,0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (!hitObject.GetComponent<PlayerCharacter> ()) {
					if (hit.distance < obstacleRange) {
						print ("in obstacle");
						float angle = Random.Range (-110, 110);
						transform.Rotate (0, angle, 0);
					}
				}	
			}
				
			 
		}


	public void SetAlive(bool alive) {
		_alive = alive;
	}

	private void Attack(){
		swordSound[1].Play();
		playercharacter = 	player.GetComponent<PlayerCharacter> ();
		playercharacter.Hurt (5f);
		//yield return new WaitForSeconds(5);
	}


	public void playerattacked(){
	
		//print ("player atatcked");
		Attack ();
	
	}





}
