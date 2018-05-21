using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpaceShip : MonoBehaviour {

	public GameObject gameGen;
	public GameObject hiderCanvas;

	public float farFactor = 200f;
	public float scaleFactor = 2f;

	public int sectorX = 0;
	public int sectorY = 0;
	public int sectorZ = 0;

	public Vector3 worldPos;
	public Star[] stars;
	public PlanetGen[] planets;

	public GameObject particles;

	public ManualLight[] manualObjects;

	Rigidbody rb;
	GameGen game;

	[HideInInspector]
	public bool inatmo = false;
	[HideInInspector]
	public bool ingrav = false;

	public float fuel = 20000f;
	Text fuelText;
	public float energy = 1000f;
	Text energyText;
	public float velocity = 1000f;
	Text velocityText;
	public float water = 10000f;
	Text waterText;
	public int peoples = 100000;
	Text peoplesText;
	public float happy = 100f;
	Text happyText;

	public List<string> modifiers;

	bool dead;
	// Use this for initialization
	void Start () {

		modifiers = new List<string>();

		if(GameObject.FindObjectsOfType<GameGen>().Length == 0) Instantiate(gameGen);
		if(GameObject.Find("Hider") == null) Instantiate(hiderCanvas);

		fuelText = GameObject.Find("Ft").GetComponent<Text>();
		energyText = GameObject.Find("Et").GetComponent<Text>();
		velocityText = GameObject.Find("Vt").GetComponent<Text>();
		waterText = GameObject.Find("Wt").GetComponent<Text>();
		peoplesText = GameObject.Find("Pt").GetComponent<Text>();
		happyText = GameObject.Find("Ht").GetComponent<Text>();

		ChangeFuel(0);
		ChangeEnergy(0);
		ChangeWater(0);
		ChangeHappy(0);
		ChangePeoples(0);

		stars = GameObject.FindObjectsOfType<Star>();
		planets = GameObject.FindObjectsOfType<PlanetGen>();

		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = Vector3.zero;
		rb.velocity = transform.forward;

		game = GameObject.FindObjectOfType<GameGen>();

		StartCoroutine(CheckObjects());
		StartCoroutine(PeopleFlow());
	}

	IEnumerator CheckObjects(){

		yield return new WaitForEndOfFrame();

		GameObject l = GameObject.Find("Loading");
		if(l != null) Destroy(l);

		stars = GameObject.FindObjectsOfType<Star>();
		planets = GameObject.FindObjectsOfType<PlanetGen>();

		foreach(Star s in stars) s.gameObject.name = "Star (check)";
		foreach(PlanetGen p in planets) p.gameObject.name = "Planet (check)";
	}

	void FixedUpdate(){
		ChangeVelocity(rb.velocity.magnitude);
	}
	
	// Update is called once per frame
	void Update () {

		//if(Application.loadedLevel != 0) return;

		if(transform.position.x < -5000){
			ChangeSector(NextSector.xMinus);
		}else if(transform.position.x > 5000){
			ChangeSector(NextSector.xPlus);
		}
		
		if(transform.position.y < -5000){
			ChangeSector(NextSector.yMinus);
		}else if(transform.position.y > 5000){
			ChangeSector(NextSector.yPlus);
		}
		
		if(transform.position.z < -5000){
			ChangeSector(NextSector.zMinus);
		}else if(transform.position.z > 5000){
			ChangeSector(NextSector.zPlus);
		}
		
		worldPos = transform.position/10000f;
		worldPos.x += sectorX;
		worldPos.y += sectorY;
		worldPos.z += sectorZ;

		foreach(Star s in stars){

			float distCalc = Vector3.Distance(worldPos,s.worldPos)/scaleFactor;

			Vector3 scale = s.sprite.localScale;
			scale.x = scale.y = s.size/distCalc;
			s.sprite.localScale = scale;

			if(scale.x > 1400f && !dead) {
				dead = true;
				modifiers.Add("солнечный удар");
			}

			s.gameObject.transform.position = transform.position;
			s.gameObject.transform.Translate((s.worldPos - worldPos)*farFactor,Space.World);

			float starIntensity = (scale.x/(farFactor/scaleFactor))/distCalc;////////(distCalc * scaleFactor)

			s.directLight.intensity = starIntensity;
			if(s.directLight.intensity < 0.05f) {
				if(s.directLight.enabled) s.directLight.enabled = false;
				//s.directLight.intensity = 0;
			}else{
				if(!s.directLight.enabled) s.directLight.enabled = true;
			}

			if(s.directLight.intensity < 0.2f) {
				if(s.directLight.shadows != LightShadows.None) s.directLight.shadows = LightShadows.None;
				//s.directLight.intensity = 0;
			}else{
				if(s.directLight.shadows == LightShadows.None) s.directLight.shadows = LightShadows.Hard;
			}

			s.pointLight.intensity = starIntensity * 4f;
			if(s.pointLight.intensity < 0.2f) {
				if(s.pointLight.enabled) s.pointLight.enabled = false;
				//s.pointLight.intensity = 0;
			}else{
				if(!s.pointLight.enabled) s.pointLight.enabled = true;
			}
		}

		foreach(PlanetGen p in planets){

			Vector3 scale = p.gameObject.transform.localScale;
			scale.x = scale.y = scale.z = p.size/(Vector3.Distance(worldPos,p.worldPos)/scaleFactor);
			p.gameObject.transform.localScale = scale;

			p.gameObject.transform.position = transform.position;
			p.gameObject.transform.Translate((p.worldPos - worldPos)*farFactor, Space.World);
		}
	}

	public void ChangeFuel(float a){
		fuel += a;
		if(fuel < 0) fuel = 0;

		fuelText.text = (int)fuel + "";
	}

	public void ChangeEnergy(float a){
		energy += a;
		if(energy < 0) energy = 0;
		
		energyText.text = (int)energy + "";
	}

	public void ChangeVelocity(float a){
		velocityText.text = (int)(a*100f) + "";
	}

	public void ChangeWater(float a){
		water += a;
		if(water < 0) water = 0;
		waterText.text = (int)water + "";
	}

	public void ChangePeoples(int a){
		peoples += a;
		if(peoples < 0) peoples = 0;
		peoplesText.text = peoples + "";
	}

	public void ChangeHappy(float a){
		happy += a;
		if(happy < 0) happy = 0;
		else if(happy > 100) happy = 100;
		happyText.text = (int)happy + "";
	}

	void OnTriggerEnter(Collider c){

		if(inatmo) return;

		switch(c.gameObject.tag){
		case "Atmosphere":

			inatmo = true;

			PlanetGen pg = c.GetComponentInParent<PlanetGen>();

			particles.GetComponent<CosmosParticles>().InAtm(pg.atmColor,
			                                                (int)pg.atmStr);

			game.landing = true;
			game.fuel = fuel;
			game.people = peoples;
			game.atmColor = pg.atmColor;
			game.str = (int)pg.atmStr/1000;
			game.angle = transform.eulerAngles.z;
			game.velo = rb.velocity.magnitude;
			GoLanding();

			break;
		/*case "Ring":
			c.GetComponent<Ring>().InRing();
			break;*/
		}
	}

	void OnTriggerStay(Collider c){

		switch(c.gameObject.tag){
		case "Planet":
			Vector3 f = (c.transform.position - transform.position).normalized / Vector3.Distance(transform.position, c.transform.position);
			rb.AddForce(f * (farFactor/scaleFactor) * .1f);
			ingrav = true;
			break;
		}
	}

	void OnTriggerExit(Collider c){
		
		switch(c.gameObject.tag){
		case "Planet":
			ingrav = false;
			break;
		}
	}

	void GoLanding(){
		StartCoroutine(game.Hide(false, Application.loadedLevel + 1));
	}

	IEnumerator PeopleFlow(){
		for(;;){
			yield return new WaitForSeconds(3);
			ChangePeoples(Random.Range(-3,3));
			if(modifiers.Contains("высокая смертность")){
				ChangePeoples(Random.Range(0,-5));
			}
            if (modifiers.Contains("нет воды"))
            {
                ChangePeoples(Random.Range(-10, -100));
            }

            ChangeEnergy(-(float)peoples/200000f);
			ChangeWater(-(float)peoples/100000f);
			ChangeHappy(-(float)peoples/5000000f);
		}
	}

	void ChangeSector(NextSector entered){

		Asteroid[] ast = GameObject.FindObjectsOfType<Asteroid>();

		switch(entered){
		case NextSector.xMinus:
			sectorX--;
			transform.Translate(10000,0,0,Space.World);
			foreach(Asteroid a in ast) a.transform.Translate(10000,0,0,Space.World);
			break;
		case NextSector.xPlus:
			sectorX++;
			transform.Translate(-10000,0,0,Space.World);
			foreach(Asteroid a in ast) a.transform.Translate(-10000,0,0,Space.World);
			break;
		case NextSector.yMinus:
			sectorY--;
			transform.Translate(0,10000,0,Space.World);
			foreach(Asteroid a in ast) a.transform.Translate(0,10000,0,Space.World);
			break;
		case NextSector.yPlus:
			sectorY++;
			transform.Translate(0,-10000,0,Space.World);
			foreach(Asteroid a in ast) a.transform.Translate(0,-10000,0,Space.World);
			break;
		case NextSector.zMinus:
			sectorZ--;
			transform.Translate(0,0,10000,Space.World);
			foreach(Asteroid a in ast) a.transform.Translate(0,0,10000,Space.World);
			break;
		case NextSector.zPlus:
			sectorZ++;
			transform.Translate(0,0,-10000,Space.World);
			foreach(Asteroid a in ast) a.transform.Translate(0,0,-10000,Space.World);
			break;
		}

		game.InSector(stars,planets,sectorX,sectorY,sectorZ,transform.position);
		
		foreach(Star s in stars){

			if(s.sectorX == sectorX && s.sectorY == sectorY && s.sectorZ == sectorZ){
				s.InSector(transform.position);
			}
		}
		
		foreach(PlanetGen p in planets){

			if(!p.far){
				if(p.sectorX != sectorX || p.sectorY != sectorY || p.sectorZ != sectorZ){
					p.OutSector();
				}
			}else if(p.sectorX == sectorX && p.sectorY == sectorY && p.sectorZ == sectorZ){
				p.InSector();
			}
		}
	}
}
