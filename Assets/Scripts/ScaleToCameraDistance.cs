using UnityEngine;
using System.Collections;

public class ScaleToCameraDistance : MonoBehaviour {
	
	private float startingDistance;
	private Vector3 startingScale;
	
	void Start()
	{
		startingDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
		startingScale = transform.localScale;
	}
	
	void Update()
	{
		//Figure out the current distance by finding the difference from starting distance
		float curDistance = startingDistance / Vector3.Distance(Camera.main.transform.position, transform.position);
		// or was it the other way around, this code is untested!
		//curDistance = (curDistance >= 0f) ? 0.000001f : curDistance;
		
		//Scale this object depending on distance away to the starting distance
		transform.localScale = startingScale * curDistance;
	}
}