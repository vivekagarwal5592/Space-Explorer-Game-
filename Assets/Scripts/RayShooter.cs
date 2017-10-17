using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera _camera;
	private AudioSource source;
	private GameObject gunobject1;
	private GameObject gunobject2;
	public int gun;

	void Start() {
		_camera = GetComponent<Camera>();
		source = GetComponent<AudioSource>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		gun = 1;
		gunobject1=	GameObject.Find("gun1");
		gunobject2= GameObject.Find("gun2");
		gunobject1.SetActive (true);
		gunobject2.SetActive (false);
	}

	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update() {
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
			source.Play();
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<Rigidbody> () != null) {
					(hitObject.GetComponent<Rigidbody> ()).AddForce(transform.forward *5);
				}
			
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					print ("hit enemy");
					target.ReactToHit();

				} 

				else {
					if (gun == 0) {
						StartCoroutine(SphereIndicator(hit.point));
					} else {
						StartCoroutine(SphereIndicator2(hit.point));
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