using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAttributeTest : MonoBehaviour
{
    [Scale(1,2,3)]
    public Transform trs;

    [SerializeField, Scale(5, 5, 5)]
    private RectTransform rtrs;

    [Scale()]
    public int notTrs;
}
