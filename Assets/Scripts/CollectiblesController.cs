using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesController : MonoBehaviour {
	[SerializeField] private GameObject collectible1;
	[SerializeField] private GameObject collectible2;
	[SerializeField] private GameObject collectible3;
	[SerializeField] private GameObject collectible4;
	[SerializeField] private GameObject collectible5;
	GameObject	_collectible;
	public Text objects;
	private int objects_remaining;
	public Text youwin;

	// Use this for initialization
	void Start () {
		_collectible= new GameObject();
		//		_food  = Instantiate (food1) as GameObject;
		//		_food  = Instantiate (food2) as GameObject;
		//		_food  = Instantiate (food3) as GameObject;
		//		_food  = Instantiate (food4) as GameObject;
		objects_remaining = 5;
		objects.text = "Objects Remaining: " + objects_remaining.ToString();

	}

	void Awake() {

		Messenger.AddListener("onCollectibleCollected",onCollectibleCollected );

	}
	void OnDestroy() {
		Messenger.RemoveListener("onCollectibleCollected",onCollectibleCollected );
	}

	// Update is called once per frame
	void Update () {

	}

	public void onCollectibleCollected(){


		objects_remaining -= 1;
		objects.text = "Objects Remaining: " + objects_remaining.ToString();

		if(objects_remaining <=0){
			youwin.text = "You Win";
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Application.LoadLevel ("scenes/game_over");
		}


		float collectible_type = (Random.value);

		if (collectible_type < 0.20f) {
			_collectible = Instantiate (collectible1) as GameObject;

		} else if(collectible_type < 0.4f){
			_collectible = Instantiate (collectible2) as GameObject;
		}

		else if(collectible_type < 0.6f){
			_collectible = Instantiate (collectible3) as GameObject;
		}

		else if(collectible_type < 0.8f){
			_collectible = Instantiate (collectible4) as GameObject;
		}

		else {
			_collectible = Instantiate (collectible5) as GameObject;
		}

		_collectible.transform.position = new Vector3(Random.Range(-98.0f, 98.0f), 1f, Random.Range(-98.0f, 98.0f));


	}



}
