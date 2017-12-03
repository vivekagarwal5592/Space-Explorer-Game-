using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject monster1;
	[SerializeField] private GameObject monster2;
	//private GameObject _enemy;
	private AudioSource backgroundSound;
	public Text enimies_killed;
	private int _enimies_killed;
	Scene scene;

	void Start(){
		backgroundSound = GetComponent<AudioSource>();
		_enimies_killed = 0;
		enimies_killed.text = "Enemies Killed: " +  _enimies_killed.ToString();
		GameObject	_enemy = new GameObject();
		_enemy = Instantiate (monster1) as GameObject;
		scene = SceneManager.GetActiveScene();

		for(int i=0;i<=2;i++){
					createNewMonster();
				}

		for(int i=0;i<=2;i++){
					createNewReptile();
				}


	}


	void Awake() {
//		Messenger.AddListener(GameEvent.ENEMY_HIT,OnEnemyDestroyed());
		Messenger<int>.AddListener("OnEnemyDestroyed",OnEnemyDestroyed );

	}
	void OnDestroy() {
		Messenger<int>.RemoveListener("OnEnemyDestroyed",OnEnemyDestroyed );
	}

	void Update() {
		if( Input.GetKeyDown(KeyCode.R))
		{
			print (SceneManager.GetActiveScene().name);
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		}
	}

	public void OnEnemyDestroyed(int enemy_no){
		

		//print(enemy_no);
		//print ("I am here");
		//int x = (int)((Random.value * 4) + 1);

	//	for (int i = 1; i <= x; i++) {
		
		if (enemy_no == 1) {
			createNewReptile();
		} else {
			if(scene.name == "scene2"){
				if(_enimies_killed <=5){
					_enimies_killed += 1;
					enimies_killed.text = "Enemies Killed: " +  _enimies_killed.ToString();
					for(int i=0;i<=1;i++){
						createNewMonster();
					}
				}
			}
			else{
				_enimies_killed += 1;
				enimies_killed.text = "Enemies Killed: " +  _enimies_killed.ToString();
				for(int i=0;i<=2;i++){
					createNewMonster();
				}
			}
		}


		if(_enimies_killed >=1){		
			if(scene.name == "scene2"){
				Messenger.Broadcast ("activateboss");
			}


		}
	}

	public void createNewMonster(){
		GameObject	_enemy2 = new GameObject();
		_enemy2 = Instantiate (monster2) as GameObject;
		Vector3 position = new Vector3(Random.Range(-98.0f, 98.0f), 0, Random.Range(-98.0f, 98.0f));
		_enemy2.transform.position = position;
		float angle = Random.Range (0, 360);
	}

	public void createNewReptile(){
		GameObject	_enemy = new GameObject();
		_enemy = Instantiate (monster1) as GameObject;
		Vector3 position = new Vector3(Random.Range(-98.0f, 98.0f), 0, Random.Range(-98.0f, 98.0f));
		_enemy.transform.position = position;
		float angle = Random.Range (0, 360);

	}



}
