using UnityEngine;
using System.Collections;

public class GameEventRevolutionEnd : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        if (FindObjectOfType<SpaceShip>().modifiers.Contains("революция!"))
        {
            if (Random.Range(0, 100) > 98) Activate();
        }
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        FindObjectOfType<SpaceShip>().ChangePeoples(-2000);
    }

    override public void RightButton()
    {
        base.RightButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(5);
    }
}
