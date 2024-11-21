using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Renderer))]
public class ShaderTest : MonoBehaviour
{
    private Renderer rend;

    public float timeSpeed;   
    
    public float ColorMultiplier { get; set; }
    //Getter , Setter ¸Þ¼­µå

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        float timeSine = Mathf.Sin(Time.time * timeSpeed * Mathf.Deg2Rad);
        timeSine = Mathf.Abs(timeSine);
        rend.material.SetFloat("_ColorMultiple", timeSine);
    }

    //public void OnValueChange(float value) 
    //{
    //    colorMultiplier = value;
    //}
}
