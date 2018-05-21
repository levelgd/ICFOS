using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GameEventRevolution : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);

        if (FindObjectOfType<SpaceShip>().modifiers.Contains("возможно восстание"))
        {
            if (Random.Range(0, 100) > 97)
            {
                FindObjectOfType<SpaceShip>().modifiers.Remove("возможно восстание");
                Activate();
            }
        }
        else if (FindObjectOfType<SpaceShip>().modifiers.Contains("высокая вероятность восстания"))
        {
            if (Random.Range(0, 100) > 80)
            {
                FindObjectOfType<SpaceShip>().modifiers.Remove("высокая вероятность восстания");
                Activate();
            }
        }
    }

    override public void WhenActivate()
    {
        FindObjectOfType<SpaceShip>().modifiers.Add("революция!");
    }

    override public void LeftButton()
    {
        base.LeftButton();
        Destroy(FindObjectOfType<EventSystem>().gameObject);
        StartCoroutine(GameObject.FindObjectOfType<GameGen>().Hide(false, 0));

    }

    override public void RightButton()
    {
        base.RightButton();

    }
}
