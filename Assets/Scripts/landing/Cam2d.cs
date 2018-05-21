using UnityEngine;
using System.Collections;

public class Cam2d : MonoBehaviour {

	public Transform parent;
	// Use this for initialization
	void Start () {
		Camera.main.backgroundColor = Color.Lerp(GameObject.FindObjectOfType<GameGen>().atmColor,Color.black,0.85f);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = parent.position;
		transform.Translate(0,-2,-10);
	}
}
