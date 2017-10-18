using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
	public const float baseSpeed = 3.0f;

	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	private GameObject player;
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;
	private Animator _animator;
	float distance = 0;
	
	private bool _alive;

//	void Awake() {
//		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
//	}
//	void OnDestroy() {
//		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
//	}

	void Start() {
		_alive = true;
		player = GameObject.Find ("player1");
		_animator = GetComponent<Animator>();
	}
	
	void Update() {

		if (_animator.GetBool ("alive") ) {
			distance = Vector3.Distance (player.transform.position, this.transform.position);
			_animator.SetFloat ("player_distance", distance);
			if (distance > 15) {
				transform.Translate (0, 0, speed * Time.deltaTime);

			} else  {
//				Vector3 movement =  new Vector3 (player.transform.eulerAngles.x,player.transform.eulerAngles.y-180 ,player.transform.eulerAngles.z);
//				transform.eulerAngles = movement;
				transform.LookAt (player.transform);
				Attack ();
			} 


			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray,0.75f, out hit)) {
					GameObject hitObject = hit.transform.gameObject;
				if (!hitObject.GetComponent<PlayerCharacter>()) {
					if (hit.distance < obstacleRange) {
						float angle = Random.Range(-110, 110);
						transform.Rotate(0, angle, 0);
					}
				}

			}

		}


		if(_fireball != null){
//			Ray fireball_ray = new Ray(_fireball.transform.position, transform.forward);
//			RaycastHit hit_object;
//			if (Physics.SphereCast(fireball_ray, 0.75f, out hit_object)) {
//				GameObject hitObject = hit_object.transform.gameObject;
//				if (hitObject.GetComponent<Camera> ()) {
//					(player.GetComponent<PlayerCharacter> ()).Hurt(2f);;
//				}
//			}
		}
		}


	public void SetAlive(bool alive) {
		_alive = alive;
	}

	private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
	}

	private void Attack(){
//		playercharacter = 	player.GetComponent<PlayerCharacter> ();
//		playercharacter.Hurt (0.1f);
//		yield return new WaitForSeconds(5);
	//	print ("in Attack");
	//	print (_fireball);
	//	print("in attack");
		if (_fireball == null) {
			print ("fireball being shot");
			_fireball = Instantiate(fireballPrefab) as GameObject;
			Vector3 p = new Vector3(0,7,1);
			_fireball.transform.position = transform.TransformPoint(p * 1f);
			_fireball.transform.rotation = transform.rotation;

				}
	}

	public void obstacle_in_front(){
	
	}

}
