using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Skill : MonoBehaviour
{
    public Sprite image;


    private void Start()
    {
       
    }

    public void onskill()
    {
        print("온스킬 사용");
    }


}
public enum skillQWER
{
    none = -1,
    Q = 0,
    W,
    E,
    R
}
