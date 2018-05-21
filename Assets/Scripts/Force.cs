using UnityEngine;
using System.Collections;

public enum BrokenType{
	none,lowForce,randForce,randOff,fullOff
}

public class Force : MonoBehaviour {

	public BrokenType brokenType = BrokenType.none;
	public float brokenStr = 0f;

	public float multipler = 1f;

	public KeyCode button;
	public KeyCode alterButton;

	public Light flame;
	Rigidbody parentRB;
	ParticleSystem particleFlame;

	SpaceShip ship;
	// Use this for initialization
	void Start () {
		flame.enabled = false;
		ship = GetComponentInParent<SpaceShip>();
		parentRB = GetComponentInParent<Rigidbody>();
		particleFlame = GetComponent<ParticleSystem>();
		particleFlame.Stop();
		particleFlame.Clear();
	}
	
	// Update is called once per frame
	void Update () {

		if(brokenStr > 0){
			if((brokenStr -= Time.deltaTime) < 0){
				brokenType = BrokenType.none;
				FindObjectOfType<StatusText>().SetText("работа поврежденного двигателя восстановлена");
				if(ship.modifiers.Contains("повреждение двигателя")){
					ship.modifiers.Remove("повреждение двигателя");
					ship.ChangeHappy(3);
				}
			}
		}

		if(ship.fuel <= 0 || brokenType == BrokenType.fullOff || ship.peoples <= 0) {
			if(particleFlame.isPlaying) particleFlame.Stop();
			if(flame.enabled) flame.enabled = false;
			return;
		}

		float ef = multipler;

		switch(brokenType){
		case BrokenType.lowForce:
			ef *= Random.Range(0.48f,0.52f);
			break;
		case BrokenType.randForce:
			ef *= Random.Range(0.1f,0.9f);
			break;
		case BrokenType.randOff:
			ef *= Random.Range(0,1);
			break;
		}

		if(Input.GetKeyDown(button) || Input.GetKeyDown(alterButton)){
			if(ef > 0){
				particleFlame.Play();
				flame.enabled = true;
			}
		}

		if(Input.GetKey(button) || Input.GetKey(alterButton)){
			if(ef > 0){
				parentRB.AddForceAtPosition(-transform.forward * ef,transform.position);
				ship.ChangeFuel(-ef);
				ship.ChangeEnergy(-multipler * 0.025f);
			}
		}

		if(Input.GetKeyUp(button) || Input.GetKeyUp(alterButton)){
			particleFlame.Stop();
			flame.enabled = false;
		}
	}

	void OnCollisionEnter(Collision c){
		int bt = Random.Range((int)brokenType,4);
		brokenType = (BrokenType)bt;
		brokenStr += Random.Range(100f,1000f);

		ship.modifiers.Add("повреждение двигателя");
		ship.ChangeHappy(-.5f);
		ship.ChangePeoples(Random.Range(10,100));
	}
}
