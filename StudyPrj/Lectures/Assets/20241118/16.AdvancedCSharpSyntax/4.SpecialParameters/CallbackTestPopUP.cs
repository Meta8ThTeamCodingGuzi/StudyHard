using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackTestPopUP : MonoBehaviour
{
    private Action<bool> callback;
    //함수를 변수화시킨다. : 함수에 이름을 붙여서 함수를 변수처럼 사용할수 있게 끔 한다. 

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowPopup(Action<bool> callback) 
    {
        gameObject.SetActive(true);
        this.callback = callback;
    }

    public void OnButtonDown(bool yes) 
    {
        callback?.Invoke(yes);
        gameObject.SetActive(false);
    }
}