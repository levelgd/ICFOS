using UnityEngine;
using System.Collections;

public class GameEventHappy60 : GameEvent {
	
	override public void CheckEvent(int t){
		base.CheckEvent(t);
		
		if(FindObjectOfType<SpaceShip>().happy <= 60 && FindObjectOfType<SpaceShip>().happy > 55) Activate();
	}
	
	override public void WhenActivate(){
		
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().ChangeEnergy(-100);
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangeWater(-100);
	}
}
