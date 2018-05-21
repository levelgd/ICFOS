using UnityEngine;
using System.Collections;

public class GameEventHappy50 : GameEvent {
	
	override public void CheckEvent(int t){
		base.CheckEvent(t);
		
		if(FindObjectOfType<SpaceShip>().happy <= 50 && FindObjectOfType<SpaceShip>().happy > 45) Activate();
	}
	
	override public void WhenActivate(){
		FindObjectOfType<SpaceShip>().modifiers.Add("высокая смертность");
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().ChangeEnergy(-200);
		FindObjectOfType<SpaceShip>().ChangeHappy(3);
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangeWater(-200);
		FindObjectOfType<SpaceShip>().ChangeHappy(3);
	}
}
