using UnityEngine;
using System.Collections;

public class GameEventFuel0e : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        SpaceShip s = FindObjectOfType<SpaceShip>();
        if (s.fuel <= 0 && s.water < 1000 && s.energy < 1000) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-5);
        FindObjectOfType<SpaceShip>().ChangeWater(-30);
        FindObjectOfType<SpaceShip>().ChangeFuel(100);
    }

    override public void RightButton()
    {
        base.RightButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-5);
        FindObjectOfType<SpaceShip>().ChangeWater(-30);
        FindObjectOfType<SpaceShip>().ChangeFuel(100);
    }
}