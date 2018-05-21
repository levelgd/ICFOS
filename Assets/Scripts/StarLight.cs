using UnityEngine;
using System.Collections;

public class StarLight : MonoBehaviour {

	Transform ship;

	// Use this for initialization
	void Start () {
		ship = FindObjectOfType<SpaceShip>().gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(ship);
	}
}
