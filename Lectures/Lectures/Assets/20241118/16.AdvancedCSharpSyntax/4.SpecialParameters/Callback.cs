using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Լ��� ȣ�� �ϰ� �� ��� � �ٸ� �Լ��� ȣ��Ǿ�� �Ҷ�, �װ��� �ݹ��Լ��� Ī�Ѵ�.
public class Callback : MonoBehaviour
{
    /*������ Ư�� �Լ� ���� �Ŀ� �ٸ� �Լ��� ȣ��Ǳ� ���Ҷ�
     *C#ver : �븮�� ���·� �ѱ�.
     *JS ver : �Լ������ͷ� �ѱ�
     */
    public GameObject destroyTarget;
    public CallbackTestPopUP popup;

    public Action callback;
    public void OnDestroyButtonClick() 
    {
        popup.ShowPopup(
            (yes) => 
            {
                if (yes) 
                {
                    Destroy(destroyTarget);
                }
                else
                {
                    print("nothing happend");
                }
            } 
            );
    }

    private void Start()
    {
        
    }
}