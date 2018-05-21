using UnityEngine;
using System.Collections;

public class PlanetIcon : MonoBehaviour {

	public Transform parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 p = Camera.main.WorldToScreenPoint(parent.position);
		if(p.z < 0) p.z = -5000;
		else p.z = 0;
		transform.position = p;
	}
}
