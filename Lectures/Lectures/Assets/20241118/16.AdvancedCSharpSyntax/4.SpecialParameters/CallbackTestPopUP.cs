using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackTestPopUP : MonoBehaviour
{
    private Action<bool> callback;
    //�Լ��� ����ȭ��Ų��. : �Լ��� �̸��� �ٿ��� �Լ��� ����ó�� ����Ҽ� �ְ� �� �Ѵ�. 

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