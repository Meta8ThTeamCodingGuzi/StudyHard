using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mamma : MonoBehaviour
{
    public Skillclr[] Skillclr;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        for(int i = 0; i < Skillclr.Length; i++)
        {
            Skillclr[i].skillKey = (skillQWER)i;
        }
    }
}
