using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UGUIToggle : MonoBehaviour
{
    public void OnValueChanged(bool isOn) 
    {
        print($"{name} ��� ���� : {isOn}");
    }
}
