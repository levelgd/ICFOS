using UnityEngine;
using System.Collections;

public class GameEventScanPlanet : GameEvent {

	int amount = 1100;

	override public void CheckEvent(int t){
		base.CheckEvent(t);

		if(FindObjectOfType<SpaceShip>().energy > amount) {
			Activate();
		}
	}
	
	override public void WhenActivate(){
		
	}
	
	override public void LeftButton(){
		base.LeftButton();
		FindObjectOfType<SpaceShip>().ChangeHappy(-2);

		amount += 200;
	}
	
	override public void RightButton(){
		base.RightButton();

		amount = 1100;

		SpaceShip ss = FindObjectOfType<SpaceShip>();

		ss.ChangeEnergy(Random.Range(-475,-525));

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

		if(nearp == null) {
			FindObjectOfType<StatusText>().SetText("Поиск не дал результатов");
			return;
		}

		if(Random.Range(0,10) > 2){
			FindObjectOfType<StatusText>().SetText("Отлично, найдена планета!");
			FindObjectOfType<SpaceShip>().ChangeHappy(5);
			nearp.Founded();
		}else{
			FindObjectOfType<StatusText>().SetText("Поиск не дал результатов");
			FindObjectOfType<SpaceShip>().ChangeHappy(-2);
		}
	}
}
