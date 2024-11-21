using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerTest : MonoBehaviour
{
    public void OnClick() 
    {
        print("Click");
    }
    public void OnEnter() 
    {
        print("enter");
    }
    public void OnExit() 
    {
        print("exit");
    }
    public void OnAnyEvent(BaseEventData eventData) 
    {
        print($"some Event Called : {(eventData as PointerEventData).position}");
    }
}
