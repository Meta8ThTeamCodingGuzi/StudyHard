using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        FPSController controller = other?.GetComponent<FPSController>();
        if (controller != null)
        {
            controller.SetJumpVelocity(jumpForce);
        }
    } 

    private void OnCollisionEnter(Collision collision)
    {
        print("collisionEnter");
    }
}
