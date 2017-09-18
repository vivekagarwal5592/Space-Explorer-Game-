using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour {

	public float speed = 3.0f;
	public float obstacleRange = 5;
	private GameObject player;
	private PlayerCharacter playercharacter;

	private bool _alive;

	void Start() {
		_alive = true;
		player = GameObject.Find ("player");
	}

	void Update() {
		if (_alive) {
			print (Vector3.Distance (player.transform.position, this.transform.position));
			if (Vector3.Distance (player.transform.position, this.transform.position) > 3) {
				transform.Translate (0, 0, speed * Time.deltaTime);
			} else {
				StartCoroutine (Attack ());
			}


			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray,0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<PlayerCharacter>()) {
					
				}
				else if (hit.distance < obstacleRange) {
					//print("hit distance  obstacle range"+hit.distance +" ,"+ obstacleRange);
					float angle = Random.Range(-110, 110);
					transform.Rotate(0, angle, 0);
				}
					
			}


		//	print (Vector3.Distance(player.transform.position, this.transform.position));
		//	if ((Mathf.Abs (player.transform.position.x - this.transform.position.x) < 5) || (Mathf.Abs (player.transform.position.z - this.transform.position.z)<5)) {
				
			if(Vector3.Distance(player.transform.position, this.transform.position) <25){


				Vector3 movement =  new Vector3 (player.transform.eulerAngles.x,player.transform.eulerAngles.y-180 ,player.transform.eulerAngles.z);
				transform.eulerAngles = movement;



			} 
				

		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	private IEnumerator Attack(){

	
		playercharacter = 	player.GetComponent<PlayerCharacter> ();
		playercharacter.Hurt (0.1f);
		yield return new WaitForSeconds(5);



	}





}
