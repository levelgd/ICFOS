using UnityEngine;
using System.Collections;

public class GameEventWater1 : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);

        if (FindObjectOfType<SpaceShip>().water < 1000) Activate();
    }

    override public void WhenActivate()
    {
        FindObjectOfType<SpaceShip>().modifiers.Add("высокая вероятность восстания");
    }

    override public void LeftButton()
    {
        base.LeftButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-10);
    }

    override public void RightButton()
    {
        base.RightButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(-10);
    }
}
