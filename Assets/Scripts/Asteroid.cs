using UnityEngine;
using System.Collections;

public enum AsteroidType{
	ice,metal,rock
}

public class Asteroid : MonoBehaviour {

	public float max = 5f;

	public AsteroidType type;

	Transform ship;
	// Use this for initialization
	void Start () {

        float sc = Random.Range(0.1f, max);

        Vector3 s = new Vector3(sc, sc, sc);
		transform.localScale = s;

		Rigidbody r = GetComponent<Rigidbody>();
		r.mass = s.magnitude;

		GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f,1f),
		                                               Random.Range(-1f,1f),
		                                               Random.Range(-1f,1f)).normalized *r.mass * Random.Range(500,2000));
		GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1f,1f),
		                                                Random.Range(-1f,1f),
		                                                Random.Range(-1f,1f)).normalized *r.mass * Random.Range(500,2000));

		ship = GameObject.FindWithTag("Player").transform;
		StartCoroutine(CheckFar());
	}
	
	void OnTriggerEnter(Collider c){
		switch(c.gameObject.tag){
		case "Atmosphere":
			Destroy(gameObject);
			break;
		}
	}

	IEnumerator CheckFar(){
		for(;;){
			yield return new WaitForSeconds(Random.Range(5,10));
			if(Vector3.Distance(ship.position,transform.position) > 10000){
				Destroy(gameObject);
				yield break;
			}else if(Vector3.Distance(ship.position,transform.position) < 10){
				switch(type){
				case AsteroidType.ice:
					SpaceShip ss = ship.GetComponent<SpaceShip>();
					ss.ChangeWater(Random.Range(5f,50f));
					ss.ChangeFuel(-2f);
					ss.ChangeEnergy(-2f);
					FindObjectOfType<StatusText>().SetText("мы добыли лед из астероида");
					break;
				case AsteroidType.rock:
					ss = ship.GetComponent<SpaceShip>();
					ss.ChangeFuel(Random.Range(5f,50f));
					ss.ChangeEnergy(-2f);
					FindObjectOfType<StatusText>().SetText("мы добыли топливо из астероида");
					break;
				}
			}
		}
	}
}
