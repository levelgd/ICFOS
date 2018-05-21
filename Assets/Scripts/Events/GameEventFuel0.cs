using UnityEngine;
using System.Collections;

public class GameEventFuel0 : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        SpaceShip s = FindObjectOfType<SpaceShip>();
        if (s.fuel <= 0 && s.water > 1000 && s.energy > 1000) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        FindObjectOfType<SpaceShip>().ChangeWater(-1000);
        FindObjectOfType<SpaceShip>().ChangeEnergy(-1000);
        FindObjectOfType<SpaceShip>().ChangeFuel(3000);
    }

    override public void RightButton()
    {
        base.RightButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-5);
        FindObjectOfType<SpaceShip>().ChangeFuel(500);
    }
}