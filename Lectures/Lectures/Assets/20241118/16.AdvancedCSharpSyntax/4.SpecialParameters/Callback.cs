using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//함수를 호출 하고 난 결과 어떤 다른 함수가 호출되어야 할때, 그것을 콜백함수라 칭한다.
public class Callback : MonoBehaviour
{
    /*보통은 특정 함수 수행 후에 다른 함수가 호출되길 원할때
     *C#ver : 대리자 형태로 넘김.
     *JS ver : 함수포인터로 넘김
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