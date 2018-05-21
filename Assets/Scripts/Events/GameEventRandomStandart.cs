using UnityEngine;
using System.Collections;

public enum ResType
{
    fuel,happy,energy,water,people
}
public class GameEventRandomStandart : GameEvent
{
    public int randomAct;
    public ResType lres;
    public int lch;

    public ResType rres;
    public int rch;

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        if (Random.Range(0, 100) > randomAct) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        switch (lres)
        {
            case ResType.energy:
                FindObjectOfType<SpaceShip>().ChangeEnergy(lch);
                break;
            case ResType.fuel:
                FindObjectOfType<SpaceShip>().ChangeFuel(lch);
                break;
            case ResType.water:
                FindObjectOfType<SpaceShip>().ChangeWater(lch);
                break;
            case ResType.people:
                FindObjectOfType<SpaceShip>().ChangePeoples(lch);
                break;
            case ResType.happy:
                FindObjectOfType<SpaceShip>().ChangeHappy(lch);
                break;
        }
    }

    override public void RightButton()
    {
        base.RightButton();
        switch (rres)
        {
            case ResType.energy:
                FindObjectOfType<SpaceShip>().ChangeEnergy(rch);
                break;
            case ResType.fuel:
                FindObjectOfType<SpaceShip>().ChangeFuel(rch);
                break;
            case ResType.water:
                FindObjectOfType<SpaceShip>().ChangeWater(rch);
                break;
            case ResType.people:
                FindObjectOfType<SpaceShip>().ChangePeoples(rch);
                break;
            case ResType.happy:
                FindObjectOfType<SpaceShip>().ChangeHappy(rch);
                break;
        }
    }
}
