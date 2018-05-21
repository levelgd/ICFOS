using UnityEngine;
using System.Collections;

public class GameEventFirstPlanet : GameEvent {

	override public void CheckEvent(int t){
		base.CheckEvent(t);
	}
	
	override public void WhenActivate(){
		SpaceShip ss = FindObjectOfType<SpaceShip>();
		
		PlanetGen[] pg = FindObjectsOfType<PlanetGen>();
		if(pg.Length == 0) return;
		
		PlanetGen nearp = pg[0];
		float neardist = 99999f;
		
		foreach(PlanetGen p in pg){
			if(p.founded) continue;
			float d = Vector3.Distance(ss.transform.position, p.transform.position);
			if(d < neardist){
				neardist = d;
				nearp = p;
			}
		}
		
		if(nearp == null) return;

		nearp.Founded();
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().ChangeHappy(3);
		FindObjectOfType<SpaceShip>().ChangeEnergy(-100);
	}
	
	override public void RightButton(){
		base.RightButton();
		FindObjectOfType<SpaceShip>().ChangeEnergy(+100);
	}
}
