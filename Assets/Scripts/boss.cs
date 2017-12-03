using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour {

	private float totalHP;
	private float CurrentHP;
	private float health;
	[SerializeField] private Image health_bar;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;
	public Color flashColor = new Color(1,0f,0f,0.1f);
	bool betrayer_found = false;
	private GameObject betrayer;
	private GameObject blast;
	private AudioSource backgroundSound;

	// Use this for initialization
	void Start () {
		backgroundSound = GetComponent<AudioSource>();
		totalHP = 10000;
		CurrentHP = totalHP;
		blast = GameObject.Find("GroundMark");
		
	}

		void Awake() {
		Messenger.AddListener("activateboss", activateboss);
	//	this.gameObject.SetActive(false);
	}
	void OnDestroy() {
		Messenger.RemoveListener("activateboss", activateboss);
	}
	
	// Update is called once per frame
	void Update () {

		float attackOpponent = Random.value;

		if(_fireball != null){
			Ray fireball_ray = new Ray(_fireball.transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(fireball_ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
				//	target.ReactToHit();
				//	Destroy(_fireball);
				}
			}
		}


		if(betrayer == null){
		if(attackOpponent >=0.8f){
			attackPlayer();
		}
		else{
				findBetrayer();
			}
		}
		else{
			attackBetrayer(betrayer);
		}
}


	public void hurt(int deduct){
		CurrentHP -= deduct;
		health_bar.transform.localScale  = new Vector3((CurrentHP/totalHP),1,1);	
		if(CurrentHP <=0){
			CurrentHP = 0;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			PlayerPrefs.SetString("winlose","YOU WIN");
			blast.transform.position = transform.position;
			Destroy(this.gameObject);
			//blast.GetComponent<ParticleSystem>().Play();
      /*ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
      em.enabled = true;*/

			//blast.particleSystem.Play();
			//Application.LoadLevel ("scenes/game_over");
Application.LoadLevel ("scenes/game_over");
     // StartCoroutine("game_over");
		}
	}

	private IEnumerator game_over(){
		print("in coroutine");
		yield return new WaitForSeconds(5f);
		Application.LoadLevel ("scenes/game_over");
	}

	public void attackPlayer(){
	transform.LookAt (player.transform);
		if (_fireball == null) {
			_fireball = Instantiate(fireballPrefab) as GameObject;
			Vector3 p = new Vector3(0,1,1);
			_fireball.transform.position = transform.TransformPoint(p * 1f);
			_fireball.transform.rotation = transform.rotation;
		  Physics.IgnoreCollision(_fireball.GetComponent<Collider>(), GetComponent<Collider>());

		}

	}

	public void findBetrayer(){
		if(betrayer ==null){
			 
			
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20);
		for ( int i = 0;i < hitColliders.Length; i++)
		{
			if(hitColliders[i].gameObject.GetComponent<WanderingAI>() != null){
				betrayer = hitColliders[i].gameObject;
				attackBetrayer(betrayer);
				break;
			}
		}
	
	}
	

	}

	public void attackBetrayer(GameObject betrayer){
		if(betrayer.GetComponent<WanderingAI>().GetAlive()== true){

		transform.LookAt (betrayer.transform);
		if (_fireball == null) {
			_fireball = Instantiate(fireballPrefab) as GameObject;
			Vector3 p = new Vector3(0,1,1);
			_fireball.transform.position = transform.TransformPoint(p * 1f);
			_fireball.transform.rotation = transform.rotation;
		}
	
}
	}

	public void activateboss(){
		if(this.gameObject !=null && !this.gameObject.activeSelf){
			this.gameObject.SetActive(true);
			this.gameObject.transform.position = new Vector3(player.transform.position.x,3,player.transform.position.z+10);
		//AudioClip clip1 = (AudioClip) Resources.Load("Audio/battle_scene");
		
		//	backgroundSound.Play();
			
		}
		
	}

}
