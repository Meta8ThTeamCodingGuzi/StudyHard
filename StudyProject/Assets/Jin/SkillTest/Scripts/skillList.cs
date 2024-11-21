using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class skillList : MonoBehaviour
{
    private static skillList instance;
    public static skillList Instance => instance;

    public List<Skill> skills =new List<Skill>();

}

