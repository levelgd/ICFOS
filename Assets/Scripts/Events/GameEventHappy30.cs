using UnityEngine;
using System.Collections;

public class GameEventHappy30 : GameEvent {
	
	override public void CheckEvent(int t){
		base.CheckEvent(t);
		
		if(FindObjectOfType<SpaceShip>().happy <= 30 && FindObjectOfType<SpaceShip>().happy > 25) Activate();
	}
	
	override public void WhenActivate(){
		
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().ChangePeoples(-2000);
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangePeoples(-100);
		FindObjectOfType<SpaceShip>().ChangeHappy(-3);
	}
}
