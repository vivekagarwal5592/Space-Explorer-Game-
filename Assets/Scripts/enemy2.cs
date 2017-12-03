	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class enemy2 : MonoBehaviour {

		public float speed = 3.0f;
		public float obstacleRange = 5;
		private GameObject player;
		private  GameObject betrayer ;
		private PlayerCharacter playercharacter;
		private AudioSource[] swordSound;
		private bool _alive;
		private bool betrayer_found;
		private Animator _animator;
		float distance ;
		private bool attack_player;
		[SerializeField] public GameObject blood;
		private GameObject _blood;

		void Start() {
			_animator = GetComponent<Animator>();
			swordSound = GetComponents<AudioSource>();
			_alive = true;
			player = GameObject.Find ("player1");
			distance = 0;
			attack_player = false;
			_blood = Instantiate(blood) as GameObject;

			_blood.GetComponent<ParticleSystem>().enableEmission = true;
			transform.Find("blood").gameObject.active = false;
		}

		void Update() {
			if (_alive) {
				_blood.transform.position = transform.position;

			if(!_blood.GetComponent<ParticleSystem>().isPlaying)
             {
             	print("blood split");
              //  _blood.GetComponent<ParticleSystem>().Play();
             }


				updateDistanceFromPlayer();
				 if (Vector3.Distance (player.transform.position,transform.position) <3) {
				 	if(attack_player == false){
				 		attack_player = true;
				 //		StartCoroutine("Attack");
				 	}
				} 
				else if(Vector3.Distance (player.transform.position,transform.position) <15){
					attack_player = false;
					move_towards_player();
				}
				else{
					lookForBetrayer();
				}

				//if(Vector3.Distance(player.transform.position,transform.position) <15) {
					
				//	roam_freely();
			//	}	
			}
		}


		public void SetAlive(bool alive) {
			_alive = alive;
		}

		public bool GetAlive(){
			return _alive;
		}

		private void Attack(){
			print("in attack");
			if(attack_player == true){
			 attackplayer();
		//	yield return new WaitForSeconds(4f);
			}
			else{
				attack_betrayer(betrayer);
			}
			}

		public void attack_betrayer(GameObject betrayer){
			 (betrayer.GetComponent<ReactiveTarget>()).ReactToHit();
		}


		public void attackplayer(){
			transform.LookAt (player.transform);
			playercharacter = player.GetComponent<PlayerCharacter> ();
			playercharacter.Hurt(5f);
			swordSound[1].Play();
		}

		public void roam_freely(){
			transform.Translate (0, 0, speed * Time.deltaTime);
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray,0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (!hitObject.GetComponent<PlayerCharacter> ()) {
					if (hit.distance < obstacleRange) {
						float angle = Random.Range (-110, 110);
						transform.Rotate (0, angle, 0);
					}
				}	
			}
		}

		public void move_towards_player(){
			Vector3 target = new Vector3(player.transform.position.x,0,player.transform.position.z);
			transform.LookAt(target);
			transform.Translate (0, 0, speed * Time.deltaTime);
		}

		public void move_towards_betrayer(){
			transform.LookAt(betrayer.transform);
			transform.Translate (0, 0, speed * Time.deltaTime);	
		}

		public void lookForBetrayer(){
			if(betrayer_found == false){
				Collider[] hitColliders = Physics.OverlapSphere(transform.position, 15);
				for ( int i = 0;i < hitColliders.Length; i++)
				{
					if(hitColliders[i].gameObject.GetComponent<WanderingAI>() != null){
						betrayer_found = true;
						betrayer = hitColliders[i].gameObject;
						break;
					}
				}
				roam_freely();

			}
			else{
				if(betrayer !=null){
					if(Vector3.Distance(betrayer.transform.position,transform.position) >3){
						move_towards_betrayer();
					}else{
						//attack_betrayer (betrayer);
					}	
				}
				else{
					betrayer_found = false;
					_animator.SetFloat ("betrayer_distance", 10);
				}
			}

		}

		public void updateDistanceFromPlayer(){
			distance = Vector3.Distance (player.transform.position, this.transform.position);
		_animator.SetFloat ("player_distance", distance);
		if(betrayer !=null){
			float bedistance = Vector3.Distance(betrayer.transform.position,transform.position);
			_animator.SetFloat ("betrayer_distance", bedistance);
		}
		}

	}
