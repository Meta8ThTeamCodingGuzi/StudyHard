using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMouseControl : MonoBehaviour
{
    private void Start()
    {
        //마우스 커서 화면에 잠금
        //Locked : 화면 중간에 잠김
        //Confined : 화면 테두리 안에 갇힘
        //None : 안잠금
        Cursor.lockState = CursorLockMode.Locked;
        //커서 보이는 여부. Editor의 경우에 따로 설정 안해도 Esc 키를 눌러도 마우스가 보임
        Cursor.visible = false;
    }
}
