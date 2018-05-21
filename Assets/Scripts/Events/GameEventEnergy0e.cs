using UnityEngine;
using System.Collections;

public class GameEventEnergy0e : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        SpaceShip s = FindObjectOfType<SpaceShip>();
        if (s.energy <= 0 && s.fuel < 1000) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-2);
        FindObjectOfType<SpaceShip>().ChangeEnergy(50);
        FindObjectOfType<SpaceShip>().ChangeWater(-50);
    }

    override public void RightButton()
    {
        base.RightButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-5);
        FindObjectOfType<SpaceShip>().ChangeEnergy(50);
    }
}