using UnityEngine;

public class GameEvent : MonoBehaviour {

	[TextArea(5,10)]
	public string mainText;
	public string leftButtonText;
	public string leftButtonDesc;
	public string leftButtonAct;
	public GameEvent lEvent;

	public string rightButtonText;
	public string rightButtonDesc;
	public string rightButtonAct;
	public GameEvent rEvent;

	public int time = -1;

	public bool onetime = true;

	public bool ok = false;

	public void SetDefault(){
		ok = false;
	}

	virtual public void CheckEvent(int t){
		if(t == time) {
			Activate();
		}
	}

	public void Activate(){

		if(onetime) ok = true;

		FindObjectOfType<ButtonAction>().ShowEvent(mainText,
		                                           leftButtonText,
		                                           leftButtonDesc,
		                                           rightButtonText,
		                                           rightButtonDesc);

		ButtonEvent[] be = FindObjectsOfType<ButtonEvent>();
		foreach(ButtonEvent b in be){
			b.gameEvent = this;
		}

		WhenActivate();
	}

	virtual public void WhenActivate(){
		
	}
	virtual public void LeftButton(){
		FindObjectOfType<ButtonAction>().HideEvent();
		FindObjectOfType<StatusText>().SetText(leftButtonAct);
		if(lEvent != null) lEvent.Activate();
	}
	virtual public void RightButton(){
		FindObjectOfType<ButtonAction>().HideEvent();
		FindObjectOfType<StatusText>().SetText(rightButtonAct);
		if(rEvent != null) rEvent.Activate();
	}
}
