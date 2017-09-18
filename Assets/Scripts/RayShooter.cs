using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera _camera;
	public int gun;
	private GameObject gunobject1;
	private GameObject gunobject2;


	void Start() {
		_camera = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		int gun = 1;
		gunobject1=	GameObject.Find("gun1");
		gunobject2= GameObject.Find("gun2");
		gunobject1.SetActive (true);
		gunobject2.SetActive (false);

	}

	void OnGUI() {
	//	print ("abshdshdh");
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/4;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
		//	Vector3 point = new Vector3(50,50, 0);
			Vector3 point = new Vector3(_camera.pixelWidth/2,_camera.pixelHeight/2, 0);
		//	Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f) );
			Ray ray = _camera.ScreenPointToRay(point);
		//	Vector3 point = new Vector3(50,30, 0);
		//	Ray ray =  Camera.main.ViewportPointToRay(point);
		//	print ("point        "+point);
		//	print ("ray"+ray);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (gun == 0) {
				//	print ("ray"+ray);
				//	print ("point");
				//	print (hit.point);
					GameObject hitObject = hit.transform.gameObject;

				//	print (hitObject);

					ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
					if (target != null) {
						target.ReactToHit();
					} else {
						StartCoroutine (SphereIndicator (hit.point));
					}
				} else {
				//	print ("I have fired with another gun");
					GameObject hitObject = hit.transform.gameObject;
					ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
					ReactiveTarget2 target2 = hitObject.GetComponent<ReactiveTarget2> ();
					if (target != null) {
						target.ReactToHit ();
					}else if(target2 !=null){
						target2.ReactToHit ();
					}

					else {
						StartCoroutine (SphereIndicator2 (hit.point));
					}
				}
			}
		}

		if (Input.GetMouseButtonDown (1)) {
			if(gun ==0){
				gun = 1;
				gunobject1.SetActive (false);
				gunobject2.SetActive (true);
			}
			else if(gun ==1){
				gunobject1.SetActive (true);
				gunobject2.SetActive (false);
				gun = 0;
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
	//	print ("I am inside SphereIndicator");
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);

		}

		private IEnumerator SphereIndicator2(Vector3 pos) {
	//	print ("I am inside SphereIndicator2");
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(cube);

	}

}