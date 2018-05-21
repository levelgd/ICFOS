using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonAction : MonoBehaviour {

	public Image[] icons;

	public GameObject eventPanel;

	public Text eventText;
	public Text lbText;
	public Desc ldesc;
	public Text rbText;
	public Desc rdesc;

	public GameObject[] toHide;
	public GameObject[] toShow;

	void Start(){
		eventPanel.SetActive(false);
	}

	void OnLevelWasLoaded(int level){
		if(level == 0) Destroy(gameObject);
	}

	public void ShowEvent(string e, string l, string ld, string r, string rd){
		eventPanel.SetActive(true);

        eventPanel.GetComponent<AudioSource>().Play();

        eventText.text = e;
		lbText.text = l;
		ldesc.descText = ld;
		rbText.text = r;
		rdesc.descText = rd;
	}

	public void HideEvent(){
		eventPanel.SetActive(false);
	}

	public void ChangeObject(int type){

		SpaceShip ss = GameObject.FindObjectOfType<SpaceShip>();
		foreach (ManualLight m in ss.manualObjects){
			if(m == ss.manualObjects[type]){
				if(m.active == true) m.Activate();
				m.active = true;
			}else{
				m.active = false;
			}
		}

		foreach(Image i in icons){
			Color c = i.color;
			c.a = 0.5f;
			i.color = c;
		}

		Color cr = icons[type].color;
		cr.a = 1f;
		icons[type].color = cr;
	}

	public void HideOnLanding(){
		foreach(GameObject h in toHide) h.SetActive(false);
		foreach(GameObject s in toShow) s.SetActive(true);
	}
}
