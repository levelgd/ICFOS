using UnityEngine;
using System.Collections;

public class GameEventVelocity25 : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        if(FindObjectOfType<SpaceShip>().velocity > 20000) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        FindObjectOfType<SpaceShip>().ChangeHappy(10);
    }

    override public void RightButton()
    {
        base.RightButton();
        FindObjectOfType<SpaceShip>().ChangeFuel(1000);
    }
}
