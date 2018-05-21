using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

	public void InRing(){
		GetComponent<ParticleSystem>().Play();
	}

	public void OutRing(){
		GetComponent<ParticleSystem>().Stop();
	}
}
