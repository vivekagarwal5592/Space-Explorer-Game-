using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_over : MonoBehaviour {

	public Text health;

	void Start() {
		health.text =  PlayerPrefs.GetString("winlose");
	}
		
	public void LoadScene(string name){
		Application.LoadLevel (name);
	}


	public void QuitGame(){
		Application.Quit ();
	}
}
