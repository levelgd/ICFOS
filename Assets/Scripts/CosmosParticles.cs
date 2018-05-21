using UnityEngine;
using System.Collections;

public class CosmosParticles : MonoBehaviour {

	public GameObject parent;

	Rigidbody parentRB;

	ParticleSystem pSystem;//
	public ParticleSystem atmo;

	public int atm = 0;
	bool isatm = false;
	// Use this for initialization
	void Start () {
		parentRB = parent.GetComponent<Rigidbody>();

		pSystem = GetComponent<ParticleSystem>();//
		pSystem.Play();
		atmo.Stop();
		atmo.Clear();
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.identity;

		transform.position = parent.transform.position;

		if(!isatm){

			transform.Translate(parentRB.velocity * 20f);

			pSystem.startSpeed = Vector3.Distance(transform.position,parent.transform.position);
            if (pSystem.startSpeed > 1000) pSystem.startSpeed = 1000f;
            pSystem.startSize = pSystem.startSpeed/750f;
			if(pSystem.startSize > 0.5f) pSystem.startSize = 0.5f;
		}else{
			transform.Translate(parentRB.velocity.normalized*5f);

			if(atm-- < 0){
				atmo.Stop();
			}
		}

		transform.LookAt(parent.transform);
	}

	public void InAtm(Color c, int str){

		if(atmo.isPlaying) return;

		isatm = true;

		atm = str/1000;

		pSystem.Stop();
		c.a = 64f/256f;
		atmo.startColor = c;
		atmo.Play();
	}

	public void OutAtm(){
		if(!atmo.isPlaying) return;

		isatm = false;
		
		pSystem.Play();
		atmo.Stop();
	}
}
