using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UGUIToggle : MonoBehaviour
{
    public void OnValueChanged(bool isOn) 
    {
        print($"{name} 토글 눌림 : {isOn}");
    }
}
