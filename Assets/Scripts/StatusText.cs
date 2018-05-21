using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusText : MonoBehaviour {

	Text text;
	bool isset = false;
	int time = 4;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}

	public void SetText(string txt){
		text.text = txt;
		time = 4;
		if(!isset){
			StartCoroutine(SetOff());
		}
		isset = true;
	}

	IEnumerator SetOff(){
		while(time-- > 0){
			yield return new WaitForSeconds(1);
		}
		text.text = "";
		isset = false;
	}
}
