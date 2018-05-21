using UnityEngine;
using System.Collections;

public class GameEventInAtmo : GameEvent {

	override public void CheckEvent(int t){
		base.CheckEvent(t);

        SpaceShip ss = FindObjectOfType<SpaceShip>();
        if (ss.ingrav && !ss.inatmo) Activate();
	}
	
	override public void WhenActivate(){
		
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().ChangeHappy(10);
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangeHappy(-5);
		FindObjectOfType<SpaceShip>().ChangeFuel(500);
	}
}
