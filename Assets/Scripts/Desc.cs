using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class Desc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public string descText = "";

	Text description;
	void Start(){
		description = GameObject.Find("Description").GetComponent<Text>();
	}
	// Use this for initialization
	public void OnPointerEnter(PointerEventData eventData)
	{
		description.text = descText;
	}
	
	public void OnPointerExit(PointerEventData eventData)
	{
		description.text = "";
	}
}
