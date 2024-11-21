using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AttributeControllerTest : MonoBehaviour
{
    [Color(0,1,0,1)]
    public Renderer rend;

    [SerializeField , Color(r:1 , b:0.5f)]
    private Graphic graph;

    [Color]
    public float notRendererOrGraphic;
}


