using UnityEngine;
using System.Collections;

public class DirIcon : MonoBehaviour {

	public Transform cam;
	public GameObject parent;
	
	Rigidbody parentRB;
	// Use this for initialization
	void Start () {
		parentRB = parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;
		transform.position = parent.transform.position;
		transform.Translate(parentRB.velocity.normalized * 5f);

		transform.rotation = cam.transform.rotation;
	}
}
