using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(Animator), typeof(RigBuilder))]
public class PlayerAction : MonoBehaviour
{
    Animator animator;
    public Rig rig;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rig = GetComponent<RigBuilder>().layers[0].rig;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            //Reload
            animator.SetTrigger("Reload");
        }
    }
}