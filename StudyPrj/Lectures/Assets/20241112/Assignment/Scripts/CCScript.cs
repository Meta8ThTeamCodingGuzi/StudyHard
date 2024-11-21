using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public TwoBoneIKConstraint aimPos;
    public Transform playerCamera;
    private bool isAiming = false;
    private float currentAimWeight = 0f;
    public float aimTransitionSpeed = 10f;

    private CharacterController characterController;
    private Animator animator;
    public Rig rig;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private float currentSpeedVelocity;
    public float speedSmoothTime = 0.1f;
    private float currentSpeed;
    private float verticalVelocity;
    public AnimationClip reloadClip;
    private WaitUntil untilReload;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rig = GetComponent<RigBuilder>().layers[0].rig;
        currentSpeed = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        untilReload = new WaitUntil(()=> isReloading);
        StartCoroutine(ReloadCoroutine());
    }

    public IEnumerator ReloadCoroutine() 
    {
        while (true) 
        {
            yield return untilReload;
            yield return new WaitForSeconds(reloadClip.length);
            isReloading = false;
            rig.weight = 1;
        }
    }

    private void Aim()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isAiming = !isAiming;
        }

        float targetWeight = isAiming ? 1f : 0f;
        currentAimWeight = Mathf.SmoothDamp(currentAimWeight, targetWeight, ref aimTransitionSpeed, Time.deltaTime);

        aimPos.weight = currentAimWeight;
    }

    private void Reload() 
    {
        if (!isReloading && Input.GetKeyDown(KeyCode.R)) 
        {
            isReloading = true;
            rig.weight = 0f;
            animator.SetTrigger("Reload");
        }
    }
    private bool isReloading = false;

    private void Fire() 
    {
        if (Input.GetMouseButton(0)) 
        {
            animator.SetTrigger("Fire");
        }
    }


    void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float inputMagnitude = Mathf.Clamp01(inputDirection.magnitude);

        float runValue = Input.GetAxis("Fire3");
        float targetSpeed = (inputMagnitude * walkingSpeed) + (runValue * (runningSpeed - walkingSpeed));
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref currentSpeedVelocity, speedSmoothTime);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = currentSpeed * Input.GetAxis("Vertical");
        float curSpeedY = currentSpeed * Input.GetAxis("Horizontal");
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (characterController.isGrounded)
        {
            verticalVelocity = -0.5f;       
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpSpeed;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;
        characterController.Move(moveDirection * Time.deltaTime);

        float animationSpeed = 0f;

        if (inputMagnitude > 0.1f)
        {
            animationSpeed = Mathf.Lerp(1f, 2f, runValue);
        }

        animator.SetFloat("Speed", animationSpeed);
        animator.SetFloat("Ydir", curSpeedX / currentSpeed);
        animator.SetFloat("Xdir", curSpeedY / currentSpeed);

        if (playerCamera != null)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        Aim();
        Reload();
        Fire();
    }
    public void SetJumpVelocity(float force)
    {
        moveDirection.y = force;
    }
}


