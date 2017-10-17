using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject monster1;
	[SerializeField] private GameObject monster2;
	//private GameObject _enemy;
	private List<GameObject> e = new List<GameObject> ();
	private AudioSource backgroundSound;

	void Start(){
		backgroundSound = GetComponent<AudioSource>();
	}


	void Awake() {
//		Messenger.AddListener(GameEvent.ENEMY_HIT,OnEnemyDestroyed());
		Messenger.AddListener("OnEnemyDestroyed",OnEnemyDestroyed );

	}
	void OnDestroy() {
		Messenger.RemoveListener("OnEnemyDestroyed",OnEnemyDestroyed );
	}

	void Update() {

		if (!backgroundSound.isPlaying)
		{
			backgroundSound.Play();
		}

		if( Input.GetKeyDown(KeyCode.R) )
		{
			print (SceneManager.GetActiveScene().name);
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		}


	}

	public void OnEnemyDestroyed(){

		print ("I am here");
		int x = (int)((Random.value * 4) + 1);

		for (int i = 1; i <= x; i++) {
			
			float monster_type = (Random.value);
			print (monster_type);
			if (monster_type > 0.5f) {
				GameObject	_enemy = new GameObject();
					_enemy = Instantiate (monster2) as GameObject;
				Vector3 position = new Vector3(Random.Range(-98.0f, 98.0f), 0, Random.Range(-98.0f, 98.0f));
			//	Vector3 position = new Vector3(10f,0f,10);
				_enemy.transform.position = position;
				float angle = Random.Range (0, 360);
			//	_enemy.transform.Rotate (0, angle + (1 * 45), 0);
			} else {
				GameObject	_enemy2 = new GameObject();
					_enemy2 = Instantiate (monster1) as GameObject;
				Vector3 position = new Vector3(Random.Range(-98.0f, 98.0f), 0, Random.Range(-98.0f, 98.0f));
			//	Vector3 position = new Vector3(10f,0f,10);
				_enemy2.transform.position = position;
				float angle = Random.Range (0, 360);
			//	_enemy2.transform.Rotate (0, angle + (1 * 45), 0);

			}
				

	
		}
	}

}
