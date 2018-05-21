using UnityEngine;
using System.Collections;

public class Leg : MonoBehaviour {

	public Rigidbody2D parent;

	public bool stay = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

	void OnCollisionStay2D(Collision2D c){
		if(parent.velocity.magnitude == 0) stay = true;
	}

	void OnCollisionExit2D(Collision2D c){
		stay = false;
	}
}
