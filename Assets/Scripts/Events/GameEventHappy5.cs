using UnityEngine;
using System.Collections;

public class GameEventHappy5 : GameEvent {

	override public void CheckEvent(int t){
		base.CheckEvent(t);
		
		if(FindObjectOfType<SpaceShip>().happy <= 9 && FindObjectOfType<SpaceShip>().happy > 0) Activate();
	}
	
	override public void WhenActivate(){
		
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().modifiers.Add("высокая вероятность восстания");
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangePeoples(-5000);
		FindObjectOfType<SpaceShip>().ChangeHappy(2);
	}
}
