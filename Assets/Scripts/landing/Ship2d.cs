using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ship2d : MonoBehaviour {

	//Leg[] legs;
	Rigidbody2D rb;
	ParticleSystem ps;

    public GameObject splash;
    bool splashed = false;

	public int atmStr = 0;

	public float fuel;
	Text fuelText;
	public int peoples;
	public float land;
	Text landText;

	bool ok;

    public AudioSource landSound;

    // Use this for initialization
    void Start () {

		FindObjectOfType<ButtonAction>().HideOnLanding();

		fuel = FindObjectOfType<GameGen>().fuel;
		peoples = FindObjectOfType<GameGen>().people;
		fuelText = GameObject.Find("Ft").GetComponent<Text>();
		landText = GameObject.Find("Ut").GetComponent<Text>();

		PlanetIcon[] pi = FindObjectsOfType<PlanetIcon>();
		foreach(PlanetIcon i in pi) Destroy(i.gameObject);

		GameGen gg = GameObject.FindObjectOfType<GameGen>();
		atmStr = gg.str;

		ps = GetComponent<ParticleSystem>();
		ps.startColor = gg.atmColor;

		transform.Rotate(0,0,gg.angle);

		rb = GetComponent<Rigidbody2D>();
		rb.centerOfMass = Vector3.zero;
		//legs = GetComponentsInChildren<Leg>();

		rb.velocity = new Vector2(0,-gg.velo*.1f);
		rb.AddTorque(Random.Range(-0.5f,0.5f));
	}
	
	// Update is called once per frame
	void Update () {

		if(atmStr-- < 0){
			ps.startSize = 0.2f;
		}

		/*bool win = true;
		foreach(Leg l in legs){
			if(l.stay == false) {
				win = false;
				break;
			}
		}*/

		landText.text = (int)transform.position.y + "";

        if(transform.position.y < 10)
        {
            if (ps.isPlaying) ps.Stop();
        }

		if(!ok && rb.velocity.magnitude == 0){
			ok = true;
			Force2d[] fc = GetComponentsInChildren<Force2d>();
			foreach(Force2d f in fc) f.gameObject.SetActive(false);
			FindObjectOfType<GameGen>().endEvent.Activate();
        }
        else
        {
            landSound.volume = Mathf.Abs(rb.velocity.normalized.y)*((500f - transform.position.y)/1000f);
        }

		/*if(win){
			//GameObject.FindObjectOfType<GameGen>().destr = true;
			StartCoroutine(GameObject.FindObjectOfType<GameGen>().Hide(false,0));
		}*/
	}

	public void End(){
		StartCoroutine(GameObject.FindObjectOfType<GameGen>().Hide(false,0));
	}

	public void ChangeFuel(float a){
		fuel += a;
		if(fuel < 0) fuel = 0;
		
		fuelText.text = (int)fuel + "";
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        peoples -= (int)(rb.velocity.magnitude * 500);
        rb.gravityScale = 0.025f;
        rb.angularDrag = 0.2f;
        rb.drag = 0.2f;
        rb.velocity = rb.velocity * .5f;

        if (!splashed)
        {
            splashed = true;
            GameObject s = Instantiate(splash, transform.position, Quaternion.identity) as GameObject;
            s.transform.Rotate(-90, 0, 0);
            s.GetComponent<ParticleSystem>().startSpeed = rb.velocity.magnitude;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        rb.gravityScale = 0.1f;
        rb.angularDrag = 0.05f;
        rb.drag = 0f;
        splashed = false;
    }
}
