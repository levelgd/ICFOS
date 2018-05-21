using UnityEngine;
using System.Collections;

public class GameEventFuel25 : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        if (FindObjectOfType<SpaceShip>().fuel <= 25000) Activate();
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
