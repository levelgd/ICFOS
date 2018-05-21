using UnityEngine;
using System.Collections;

public class GameEventHappy70 : GameEvent {
	
	override public void CheckEvent(int t){
		base.CheckEvent(t);
		
		if(FindObjectOfType<SpaceShip>().happy <= 70 && FindObjectOfType<SpaceShip>().happy > 65) Activate();
	}
	
	override public void WhenActivate(){
		
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().ChangeEnergy(50);
		FindObjectOfType<SpaceShip>().ChangeHappy(-3);
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangeEnergy(-100);
	}
}
