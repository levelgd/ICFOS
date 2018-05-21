using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject loadingScreen;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(loadingScreen);
		loadingScreen.SetActive(false);
	}

	public void NewGame(){
		loadingScreen.SetActive(true);
        Application.LoadLevelAsync(Application.loadedLevel + 1);
    }

	public void Options(){

	}
	public void Exit(){
		Application.Quit();
	}

	void Update(){
		transform.Rotate(0,Time.deltaTime,0);
	}
}
