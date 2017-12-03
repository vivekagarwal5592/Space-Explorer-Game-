using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class foodController : MonoBehaviour {

	[SerializeField] private GameObject food1;
	[SerializeField] private GameObject food2;
	[SerializeField] private GameObject food3;
	[SerializeField] private GameObject food4;
	GameObject	_food;
	private GameObject player;
	private PlayerCharacter playercharacter;
	private AudioSource s;

	// Use this for initialization
	void Start () {
		_food = new GameObject();
		s = this.gameObject.GetComponent<AudioSource>();
//		_food  = Instantiate (food1) as GameObject;
//		_food  = Instantiate (food2) as GameObject;
//		_food  = Instantiate (food3) as GameObject;
//		_food  = Instantiate (food4) as GameObject;
		player = GameObject.Find ("player1");
		playercharacter = 	player.GetComponent<PlayerCharacter> ();


	}

	void Awake() {
		
		Messenger.AddListener("onFoodCollected",onFoodCollected );

	}
	void OnDestroy() {
		Messenger.RemoveListener("onFoodCollected",onFoodCollected );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onFoodCollected(){

		s.Play();
		playercharacter.food_eaten ();
			float food_type = (Random.value);

			if (food_type > 0.25f) {
			_food = Instantiate (food1) as GameObject;
		} else if(food_type > 0.5f){
			_food = Instantiate (food2) as GameObject;
			}

		else if(food_type > 0.75f){
			_food = Instantiate (food3) as GameObject;
		}

		else {
			_food = Instantiate (food4) as GameObject;
		}

		_food.transform.position = new Vector3(Random.Range(-98.0f, 98.0f), 0, Random.Range(-98.0f, 98.0f));
	}


}
