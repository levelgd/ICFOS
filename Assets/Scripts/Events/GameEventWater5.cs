using UnityEngine;
using System.Collections;

public class GameEventWater5 : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);

        if (FindObjectOfType<SpaceShip>().water < 5000) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-1);
    }

    override public void RightButton()
    {
        base.RightButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-1);
    }
}
