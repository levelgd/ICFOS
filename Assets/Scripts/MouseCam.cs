using UnityEngine;
using System.Collections;

public class MouseCam : MonoBehaviour {

	public Transform cam;

	public int maxUp = 90;
	public int maxDown = -90;

	public int maxFar = 5;
	public int maxNear = 1;
	
	private Vector3 rotPoint;
	private float upRot = 0f;
	private float rightRot = 20f;
	private float backDist = 5f;
	// Use this for initialization
	void Start () {
		cam.transform.rotation = Quaternion.identity;			
		cam.transform.position = transform.position;
		cam.transform.Rotate(rightRot,upRot, 0);
		cam.transform.Translate(Vector3.back * backDist);
	}
	
	// Update is called once per frame
	void Update () {
		backDist -= Input.GetAxis("Mouse ScrollWheel")*3;

		if(backDist > maxFar) backDist = maxFar;
		else if(backDist < maxNear) backDist = maxNear;

		if(Input.GetMouseButton(1))
		{		
			upRot += Input.GetAxis("Mouse X")*3;
			rightRot -= Input.GetAxis("Mouse Y")*3;
			
			if (rightRot > maxUp) rightRot = maxUp;
			else if (rightRot < maxDown) rightRot = maxDown;
		}
	}

	void LateUpdate() {
		cam.transform.position = transform.position;
		cam.transform.rotation = transform.rotation;			
		
		cam.transform.Rotate(rightRot, upRot, 0);
		
		cam.transform.Translate(0,0,-backDist);
	}
}
