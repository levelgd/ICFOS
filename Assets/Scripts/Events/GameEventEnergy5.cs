using UnityEngine;
using System.Collections;

public class GameEventEnergy5 : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        if (FindObjectOfType<SpaceShip>().energy <= 500) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
    }

    override public void RightButton()
    {
        base.RightButton();
    }
}