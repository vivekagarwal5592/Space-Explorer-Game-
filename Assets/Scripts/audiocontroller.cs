using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audiocontroller : MonoBehaviour {

	AudioSource[] audios ;
	Scene scene;
	GameObject boss;
	

	void Start () {
		//aSources = GetComponents<AudioSource>();
		audios = this.gameObject.GetComponents<AudioSource>();
		scene = SceneManager.GetActiveScene();
		boss = GameObject.Find("boss");
		
	}
	
	// Update is called once per frame
	void Update () {
		

		

	if(scene.name == "intro"){
		
		if(!audios[0].isPlaying){
			audios[0].Play();
		}
				}

	if(scene.name == "scene1"){
		if(!audios[1].isPlaying){
			audios[1].Play();
		}
				}

	if(scene.name == "scene2"){
		if(boss !=null && boss.activeSelf){
			
			if(!audios[2].isPlaying){
			audios[2].Play();
		}
	}
		else{
			
		if(!audios[1].isPlaying){

			audios[1].Play();
		}	
		}
		

		
				}

		
	}
}
