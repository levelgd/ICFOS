using UnityEngine;
using System.Collections;

public class GameEventStartEnd : GameEvent {

	override public void CheckEvent(int t){
		base.CheckEvent(t);
	}
	
	override public void WhenActivate(){
		
	}
	
	override public void LeftButton(){
		base.LeftButton();
	}
	
	override public void RightButton(){
		base.RightButton();
		Application.Quit();
	}
}
