using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GameEventRevolution2 : GameEvent
{

    override public void CheckEvent(int t)
    {
        base.CheckEvent(t);
    }

    override public void WhenActivate()
    {

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
        Destroy(FindObjectOfType<EventSystem>().gameObject);
        StartCoroutine(GameObject.FindObjectOfType<GameGen>().Hide(false, 0));
    }
}
