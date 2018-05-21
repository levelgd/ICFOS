using UnityEngine;
using System.Collections;

public class GameEventHappy90 : GameEvent {
	
	override public void CheckEvent(int t){
		base.CheckEvent(t);
		
		if(FindObjectOfType<SpaceShip>().happy >= 90) Activate();
	}
	
	override public void WhenActivate(){
		if(FindObjectOfType<SpaceShip>().modifiers.Contains("высокая смертность")){
			FindObjectOfType<SpaceShip>().modifiers.Remove("высокая смертность");
		}
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().ChangeWater(100);
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangeEnergy(100);
	}
}