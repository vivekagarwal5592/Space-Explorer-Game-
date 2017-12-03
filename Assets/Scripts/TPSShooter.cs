using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSShooter : MonoBehaviour {

	private AudioSource source;
	public int gun;
	private GameObject cameraObject;
	private Camera _camera;
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;

	// Use this for initialization
	void Start () {	
		cameraObject=GameObject.Find("Secondary Camera");
		_camera = cameraObject.GetComponent<Camera>();
		source = this.gameObject.GetComponent<AudioSource>();
		gun = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) ) {
			source.Play();
			turnplayer();
		//	firebullet();

		}
	}


	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;
		yield return new WaitForSeconds(1);
		Destroy(sphere);
	}

	private IEnumerator SphereIndicator2(Vector3 pos) {
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = pos;
		yield return new WaitForSeconds(1);
		Destroy(cube);
		}

	public void firebullet(Vector3 direction){

			_fireball = Instantiate(fireballPrefab) as GameObject;
			Vector3 p = new Vector3(0,1,1);
			_fireball.transform.position = transform.TransformPoint(p * 1f);
			//_fireball.transform.rotation = transform.rotation;
			//_fireball.transform.Rotate(0,45,0);
			_fireball.transform.LookAt (direction);
		  Physics.IgnoreCollision(_fireball.GetComponent<Collider>(), GetComponent<Collider>());
			//Ray fireball_ray = new Ray(_fireball.transform.position, transform.forward);
			/*RaycastHit hit1;
			if (Physics.SphereCast(fireball_ray, 0.75f, out hit1)) {
				GameObject hitObject = hit1.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
				}
			}*/
	}

	public void turnplayer(){

			RaycastHit hit;
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
			Vector3 bullet_direction;
			if (Physics.Raycast(ray,out hit)){
				GameObject hitObject = hit.transform.gameObject;    	
				//Vector3 targetDir = hit.transform.position - transform.position;
				float step = 3.0f * Time.deltaTime;
				Quaternion rotation = Quaternion.LookRotation(hit.transform.position);
				Vector3 newDir = hit.point;
				bullet_direction = newDir;
				newDir.y=0;
				transform.LookAt(newDir);
				print(newDir);
         
				if (hitObject.GetComponent<Rigidbody> () != null) {
					(hitObject.GetComponent<Rigidbody> ()).AddForce(transform.forward *5);
				}

				boss target2 = hitObject.GetComponent<boss>();
				 if(target2 != null){
					target2.hurt(100);
				}
				else{if (gun == 0) {} else {}}

				firebullet(bullet_direction);
				
			}	
		//	bullet_direction.z = 1;
			print(bullet_direction);

			
	}
}


