using UnityEngine;
using System.Collections;

public class GameEventEnergy1 : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        if (FindObjectOfType<SpaceShip>().energy <= 100) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-2);
    }

    override public void RightButton()
    {
        base.RightButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-5);
        FindObjectOfType<SpaceShip>().ChangeFuel(500);
    }
}