using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewController : MonoBehaviour {

	private GameObject player;
	private GameObject camera;
	private GameObject bosscamera;
	private GameObject secondaryCamera;
	private GameObject boss;
	bool cameraControlChanged;


	void Start () {
		player = GameObject.Find ("player1");
		camera = GameObject.Find("Main Camera");
	//	bosscamera = GameObject.Find("bosscamera");
		secondaryCamera = GameObject.Find("Secondary Camera");
		Scene scene = SceneManager.GetActiveScene();
		boss = GameObject.Find ("boss");
		boss.active = false;
	//	bosscamera.active = false;
		cameraControlChanged = false;

if(scene.name == "scene1"){

	player.GetComponent<PlayerCharacter>().enabled = true;
			player.GetComponent<FPSInput>().enabled = true;
			player.GetComponent<MouseLook>().enabled = true;
			player.GetComponent<RelativeMovement>().enabled = false;
			camera.GetComponent<RayShooter>().enabled = true;
			camera.GetComponent<MouseLook>().enabled = true;
			camera.active = true;
			secondaryCamera.GetComponent<OrbitCamera>().enabled = false;
			secondaryCamera.active = false;
}
else{
			player.GetComponent<FPSInput>().enabled = false;
			player.GetComponent<MouseLook>().enabled = false;
			player.GetComponent<RelativeMovement>().enabled = true;
			camera.GetComponent<RayShooter>().enabled = false;
			camera.GetComponent<MouseLook>().enabled = false;
			camera.active = false;
			secondaryCamera.active = true;
			secondaryCamera.GetComponent<OrbitCamera>().enabled = true;

			
}

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.V)) {
		//	print("V pressed");
			/*player.GetComponent<PlayerCharacter>().enabled = true;
			player.GetComponent<FPSInput>().enabled = true;
			player.GetComponent<MouseLook>().enabled = true;
			player.GetComponent<RelativeMovement>().enabled = false;

			camera.GetComponent<RayShooter>().enabled = true;
			camera.GetComponent<MouseLook>().enabled = true;
			camera.active = true;

			
			secondaryCamera.GetComponent<OrbitCamera>().enabled = false;
			secondaryCamera.active = false;
			*/
		}
		
		else
		{
			/*player.GetComponent<PlayerCharacter>().enabled = false;
			player.GetComponent<FPSInput>().enabled = false;
			player.GetComponent<MouseLook>().enabled = false;
			player.GetComponent<RelativeMovement>().enabled = true;

			camera.GetComponent<RayShooter>().enabled = false;
			camera.GetComponent<MouseLook>().enabled = false;
			camera.active = false;

			secondaryCamera.active = true;
			secondaryCamera.GetComponent<OrbitCamera>().enabled = true;
			*/
		}


		if(boss !=null ){
			/*if(boss.activeSelf){
			

			if(cameraControlChanged == false){
				bosscamera.active = true;
				secondaryCamera.active = false;
			secondaryCamera.GetComponent<OrbitCamera>().enabled = false;
				cameraControlChanged = true;
			}
		}*/

}
		
	}
}
