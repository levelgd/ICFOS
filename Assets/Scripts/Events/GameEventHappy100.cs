using UnityEngine;
using System.Collections;

public class GameEventHappy100 : GameEvent {

	override public void CheckEvent(int t){
		base.CheckEvent(t);

		if(FindObjectOfType<SpaceShip>().happy >= 100) Activate();
	}
	
	override public void WhenActivate(){
		
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().ChangeWater(500);
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangeEnergy(500);
	}
}
