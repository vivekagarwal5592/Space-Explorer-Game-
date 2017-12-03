using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public void LoadScene(string name){
		Application.LoadLevel(name);
	}
		
	public void QuitGame(){
		Application.Quit ();
	}
}
