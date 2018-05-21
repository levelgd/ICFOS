using UnityEngine;
using System.Collections;

public class GameEventHappy15 : GameEvent {
	
	override public void CheckEvent(int t){
		base.CheckEvent(t);
		
		if(FindObjectOfType<SpaceShip>().happy <= 17 && FindObjectOfType<SpaceShip>().happy > 10) Activate();
	}
	
	override public void WhenActivate(){
		
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().modifiers.Add("возможно восстание");
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangeWater(-300);
		FindObjectOfType<SpaceShip>().ChangeEnergy(-300);
	}
}
