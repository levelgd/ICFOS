using UnityEngine;
using System.Collections;

public class GameEventFuel5 : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        if (FindObjectOfType<SpaceShip>().fuel <= 5000) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        FindObjectOfType<SpaceShip>().ChangeWater(-1000);
        FindObjectOfType<SpaceShip>().ChangeFuel(2000);
    }

    override public void RightButton()
    {
        base.RightButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-5);
    }
}