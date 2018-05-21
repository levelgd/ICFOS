using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameGen : MonoBehaviour {

    public AudioClip[] ambients;
    AudioSource audioSource;

	public GameEvent[] events;
	public GameEvent endEvent;
    [HideInInspector]
    public int time = 0;

	public GameObject star;
	public int numStars = 5;
	//public GameObject hiderCanvas;
	public GameObject[] asteroids;

	public Image hider;

	public int str = 0;
	public Color atmColor = Color.black;
	public float angle = 0f;
	public float velo = 0f;
	public bool landing = false;

	public float fuel;
	public int people;

	public bool destr = false;

	void Start () {

		while(numStars-- > 0) Instantiate(star);

		DontDestroyOnLoad(gameObject);

		hider = GameObject.Find("Hider").GetComponent<Image>();
		DontDestroyOnLoad(hider.transform.parent.gameObject);
		StartCoroutine(Hide(true, -1));

		foreach(GameEvent e in events) e.SetDefault();

		StartCoroutine(EventGen());
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAmbient());
    }

	void OnLevelWasLoaded(int level){
		if(level == 0) Destroy(gameObject);
	}

    IEnumerator PlayAmbient()
    {
        for (;;)
        {
            yield return new WaitForSeconds(1);
            if (audioSource.isPlaying) continue;
            audioSource.clip = ambients[Random.Range(1, ambients.Length-1)];
            if (landing) audioSource.clip = ambients[0];
            audioSource.Play();
        }
    }

    public IEnumerator EventGen(){
		for(;;){
			yield return new WaitForSeconds(15);

			if(landing) yield break;

            GameObject panel = FindObjectOfType<ButtonAction>().eventPanel;

            if (panel.activeSelf) continue;

			time++;
			//Debug.Log(time);
			foreach(GameEvent e in events){
				if(!e.ok) e.CheckEvent(time);
                if (panel.activeSelf) break;
			}
		}
	}

	public IEnumerator Hide(bool start, int load){

		if(start){
			hider.gameObject.SetActive(true);
			while(true){
				yield return new WaitForEndOfFrame();
				Color c = hider.color;
				c.a -= Time.deltaTime * 0.1f;
				if(c.a <= 0f){
					c.a = 0f;
					hider.gameObject.SetActive(false);
					if(load > -1) {
						Application.LoadLevel(load);
						StartCoroutine(Hide(true, -1));
					}
					yield break;
				}
				hider.color = c;
			}
		}else{
			hider.gameObject.SetActive(true);
			while(true){
				yield return new WaitForEndOfFrame();
				Color c = hider.color;
				c.a += Time.deltaTime*0.5f;
				if(c.a >= 1f){
					c.a = 1f;
					if(load > -1) {
						Application.LoadLevel(load);
						StartCoroutine(Hide(true, -1));
					}
					yield break;
				}
				hider.color = c;
			}
		}
	}

	public void InSector(Star[] stars, PlanetGen[] planets,int x,int y,int z, Vector3 pos){

		Asteroid[] ast = GameObject.FindObjectsOfType<Asteroid>();
		foreach(Asteroid a in ast){
			if(Vector3.Distance(pos,a.transform.position) > 2000) Destroy(a.gameObject);
		}

		foreach(Star s in stars){
			if(s.sectorX == x && s.sectorY == y && s.sectorZ == z) return;
		}
		
		foreach(PlanetGen p in planets){
			if(p.sectorX == x && p.sectorY == y && p.sectorZ == z) return;
		}

		int asters = Random.Range(0,15);
		while(asters-- > 0){
			Instantiate(asteroids[Random.Range(0,asteroids.Length - 1)],
			                      new Vector3(Random.Range(-3000f,3000f),Random.Range(-3000f,3000f),Random.Range(-3000f,3000f)),
			                      Quaternion.identity);
		}
	}
}
