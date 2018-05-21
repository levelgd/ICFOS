using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	public int sectorX = 0;
	public int sectorY = 0;
	public int sectorZ = 0;

	public float size;

	public Transform sprite;
	public Vector3 worldPos;

	public Light directLight;
	public Light pointLight;

	public GameObject planetPrefab;

    float spaceScale = 30f;

	// Use this for initialization
	void Start () {

		name = "Star (check on second pass)";

		SpriteRenderer s = GetComponentInChildren<SpriteRenderer>();

		int starcolor = Random.Range(1,4);
		float m = Random.Range(0.01f,0.2f);
		switch(starcolor){
		case 1:
			s.color = new Color(1f-m,1f,1f);
			break;
		case 2:
			s.color = new Color(1f-m,1f-m,1f);
			break;
		case 3:
			s.color = new Color(1f,1f,1f-m*2);
			break;
		case 4:
			s.color = new Color(1f,1f,1f);
			break;
		}

		directLight.color = s.color;
		pointLight.color = s.color;

		size = Random.Range(50f,1000f);

		worldPos = new Vector3(
            Random.Range(-spaceScale, spaceScale),
            Random.Range(-spaceScale, spaceScale),
            Random.Range(-spaceScale, spaceScale));
		//worldPos = new Vector3(1.4f,.1f,.1f);
		transform.position = worldPos;

		sectorX = Mathf.RoundToInt(worldPos.x);
		sectorY = Mathf.RoundToInt(worldPos.y);
		sectorZ = Mathf.RoundToInt(worldPos.z);

		if(sectorX == 0 && sectorY == 0 && sectorZ == 0) Destroy(gameObject);
		else {
			GenPlanets();
		}
	}

	public void GenPlanets(){

		int i = Random.Range(-5,5);
		//int i = 1;
		if(i < 1) return;

		while(i-- > 0){
			float rng = Random.Range(3f, 15f);
			Vector3 orbit = new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f));
			Instantiate(planetPrefab, worldPos + orbit.normalized*rng, Quaternion.identity);
			//Instantiate(planetPrefab, new Vector3(1f,1f,1f), Quaternion.identity);
		}
	}

	public void InSector(Vector3 shipPos){

	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
}
