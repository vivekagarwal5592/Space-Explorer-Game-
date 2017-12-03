using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	private Animator _animator;
	private AudioSource source;

	void Start() {
		source = GetComponent<AudioSource>();
	}

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
		enemy2 behavior2 = GetComponent<enemy2>();

		_animator=this.GetComponent<Animator> ();
		if (behavior != null) {
			behavior.SetAlive(false);
			StartCoroutine(Die());
		}
		else if(behavior2 !=null){
			behavior2.SetAlive(false);
			StartCoroutine(Die());
		}


	}

	private IEnumerator Die() {
		source.Play();
		_animator.SetBool ("hit",true);

		_animator.SetBool ("alive",false);

		//_animator.Play ("Death"); 

	//	print ("after die");
		//this.transform.Rotate(-75, 0, 0);

		yield return new WaitForSeconds(4f);

		if(this.gameObject.GetComponent<enemy2>() != null){
			Messenger<int>.Broadcast("OnEnemyDestroyed",2);
		}
		else{
			Messenger<int>.Broadcast("OnEnemyDestroyed",1);
		}

		
		Destroy(this.gameObject);

	}
}
