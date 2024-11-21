using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator), typeof(RigBuilder))]
public class InputSystemAction : MonoBehaviour
{
    private Animator animator;
    private Rig rig;
    private WaitUntil untilReload;
    private WaitForSeconds waitSec;
    private bool isReloading;
    public AnimationClip reloadClip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rig = GetComponent<RigBuilder>().layers[0].rig;
    }

    private IEnumerator Start()
    {
        untilReload = new WaitUntil(() => isReloading);
        waitSec = new WaitForSeconds(reloadClip.length);
        while (true)
        {
            yield return untilReload;
            yield return waitSec;
            isReloading = false;
            rig.weight = 1f;
        }
    }

    public void OnReloadEvent(InputAction.CallbackContext context) 
    {
        if (isReloading) return;
        if (context.performed) 
        {
            rig.weight = 0f;
            isReloading = true;
            animator.SetTrigger("Reload");
        }
    }

    private void OnReload(InputValue value)
    {
        print($"OnReload »£√‚µ . isPressed : {value.isPressed} {value.Get<Single>()}");
        if (isReloading) return;
        rig.weight = 0f;
        isReloading = true;
        animator.SetTrigger("Reload");
    }
}
