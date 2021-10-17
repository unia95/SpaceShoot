using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, interface_1 {

	public void PlayGame(){
		SceneManager.LoadScene ("Done_main");
		
	}

	public void LoadGame(){
		//SceneManager.LoadScene ("Done_main");

	}

	public void EnterTutorial(){
		SceneManager.LoadScene ("TutorialScene");
	}


	public void QuitGame(){
		Application.Quit ();
	}


}
