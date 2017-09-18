using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject dragon;
	[SerializeField] private GameObject zombie;
	private GameObject _enemy;
	private GameObject _enemy2;
	private List<GameObject> e = new List<GameObject> ();
	void Update() {
		//print ("count:"+e.Count);
		if (_enemy == null) {
		//	e.Remove (_enemy);
//			_enemy = Instantiate(dragon) as GameObject;
//			_enemy.transform.position = new Vector3(0, 1, 0);
//			float angle = Random.Range(0, 360);
//			_enemy.transform.Rotate(0, angle, 0);

		//	if (e.Count <= 15) {

				int x = (int)((Random.value * 4) + 2);
			//print("x"+x);
			print ("spwaing enenmy1");
				for (int i = 2; i <= x; i++) {

						_enemy = Instantiate (dragon) as GameObject;
					//Vector3 position = new Vector3(Random.Range(-50.0f, 50.0f), 2, Random.Range(-50.0f, 50.0f));
					_enemy.transform.position = new Vector3(0,1,0);
								float angle = Random.Range(0, 360);
								_enemy.transform.Rotate(0, angle, 0);

			//		e.Add (_enemy);
		//		}
			}

		}
		if (_enemy2 == null) {
			print ("spwaing enenmy2");
		//	e.Remove (_enemy2);
			int x = (int)((Random.value * 4) + 2);
		//	print ("x" + x);
			for (int i = 2; i <= x; i++) {

				_enemy2 = Instantiate (zombie) as GameObject;
			//	Vector3 position = new Vector3(Random.Range(-50.0f, 50.0f), 2, Random.Range(-50.0f, 50.0f));
				_enemy2.transform.position = new Vector3(0,1.7f,0);
				float angle = Random.Range(0, 360);
				_enemy2.transform.Rotate(0, angle, 0);

		//		e.Add (_enemy2);
			}
		}


		if( Input.GetKeyDown("space") )
		{
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		}


	}


}
