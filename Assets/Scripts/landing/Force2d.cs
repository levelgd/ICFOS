using UnityEngine;
using System.Collections;

public class Force2d : MonoBehaviour {

	public float multipler = 1f;

	public KeyCode button;

	Rigidbody2D parentRB;
	ParticleSystem particleFlame;

	Ship2d ship;

    AudioSource engine;
	// Use this for initializations
	void Start () {
		parentRB = GetComponentInParent<Rigidbody2D>();
		particleFlame = GetComponent<ParticleSystem>();
		particleFlame.Stop();
		particleFlame.Clear();

        engine = GetComponent<AudioSource>();

        ship = GetComponentInParent<Ship2d>();
	}
	
	// Update is called once per frame
	void Update () {

		if(ship.fuel <= 0 || ship.peoples <= 0){
			if(particleFlame.isPlaying) particleFlame.Stop();
            if (engine.isPlaying) engine.Stop();
            return;
		}

		if(Input.GetKeyDown(button)){
			particleFlame.Play();
            engine.Play();
        }
		
		if(Input.GetKey(button)){
			parentRB.AddForceAtPosition(-transform.forward * multipler * 10f,transform.position);
			ship.ChangeFuel(-2f);
		}
		
		if(Input.GetKeyUp(button)){
			particleFlame.Stop();
            engine.Stop();
        }
	}
}
