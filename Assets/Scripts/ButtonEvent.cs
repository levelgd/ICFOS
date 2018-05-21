using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public enum ButtonType{
	left,right
}

public class ButtonEvent : MonoBehaviour, IPointerClickHandler {

	public ButtonType type;
	public GameEvent gameEvent;

	Text description;

	void Start(){
		description = GameObject.Find("Description").GetComponent<Text>();
	}

	public void OnPointerClick(PointerEventData eventData){
		switch(type){
		case ButtonType.left:
                FindObjectOfType<ButtonAction>().GetComponent<AudioSource>().Play();
			    gameEvent.LeftButton();
			break;
		case ButtonType.right:
                FindObjectOfType<ButtonAction>().GetComponent<AudioSource>().Play();
                gameEvent.RightButton();
			break;
		}

		description.text = "";
	}
}
