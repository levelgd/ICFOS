using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GameEventSunDead : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
        if (FindObjectOfType<SpaceShip>().modifiers.Contains("солнечный удар")) Activate();
    }

    override public void WhenActivate()
    {

    }

    override public void LeftButton()
    {
        base.LeftButton();
        Destroy(FindObjectOfType<EventSystem>().gameObject);
        Application.Quit();
        //StartCoroutine(GameObject.FindObjectOfType<GameGen>().Hide(false,0));
    }

    override public void RightButton()
    {
        base.RightButton();
        Destroy(FindObjectOfType<EventSystem>().gameObject);
        Application.Quit();
        //StartCoroutine(GameObject.FindObjectOfType<GameGen>().Hide(false, 0));
    }
}
