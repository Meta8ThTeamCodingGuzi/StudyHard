using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class TPSController : MonoBehaviour
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
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isRunning = false;
    private bool isJumping = false;
    private bool isFiring = false;
    private bool isReloading = false;
    private float targetRunMultiplier = 1f;
    private float currentRunMultiplier = 1f;
    private float runVelocity;
    private Vector2 currentMoveInput;
    private Vector2 moveInputVelocity;
    private float currentAnimationSpeed = 0f;
    private float animationSpeedVelocity;
    public float fireRate = 10f;  // 분당 발사 횟수
    private float timeBetweenShots;  // 발사 간격
    private bool canFire = true;
    private Coroutine fireCoroutine;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rig = GetComponent<RigBuilder>().layers[0].rig;
        currentSpeed = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        untilReload = new WaitUntil(() => isReloading);
        StartCoroutine(ReloadCoroutine());
        timeBetweenShots = 60f / fireRate;  // 분당 발사 횟수를 초 단위 간격으로 변환
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

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleActions();
    }

    private void HandleMovement()
    {
        currentMoveInput = Vector2.SmoothDamp(
            currentMoveInput,
            moveInput,
            ref moveInputVelocity,
            speedSmoothTime
        );

        Vector3 inputDirection = new Vector3(currentMoveInput.x, 0, currentMoveInput.y);
        float inputMagnitude = Mathf.Clamp01(inputDirection.magnitude);

        currentRunMultiplier = Mathf.SmoothDamp(currentRunMultiplier, targetRunMultiplier, ref runVelocity, speedSmoothTime);
        float targetSpeed = walkingSpeed * currentRunMultiplier;
        targetSpeed *= inputMagnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref currentSpeedVelocity, speedSmoothTime);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = currentSpeed * currentMoveInput.y;
        float curSpeedY = currentSpeed * currentMoveInput.x;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        ApplyGravity();

        characterController.Move(moveDirection * Time.deltaTime);

        UpdateMovementAnimation(inputMagnitude, curSpeedX, curSpeedY);
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        moveDirection.y = verticalVelocity;
    }

    private void UpdateMovementAnimation(float inputMagnitude, float curSpeedX, float curSpeedY)
    {
        float targetAnimationSpeed = 0f;
        if (inputMagnitude > 0.1f)
        {
            targetAnimationSpeed = isRunning ? 2f : 1f;
        }

        currentAnimationSpeed = Mathf.SmoothDamp(
            currentAnimationSpeed,
            targetAnimationSpeed,
            ref animationSpeedVelocity,
            speedSmoothTime
        );

        animator.SetFloat("Speed", currentAnimationSpeed);
        animator.SetFloat("Ydir", curSpeedX / (currentSpeed + 0.01f));
        animator.SetFloat("Xdir", curSpeedY / (currentSpeed + 0.01f));
    }

    private void HandleRotation()
    {
        if (playerCamera != null)
        {
            rotationX += -lookInput.y * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, lookInput.x * lookSpeed, 0);
        }
    }

    private void HandleActions()
    {
        HandleAiming();
        HandleFiring();
    }

    private void HandleAiming()
    {
        float targetWeight = isAiming ? 1f : 0f;
        currentAimWeight = Mathf.SmoothDamp(currentAimWeight, targetWeight, ref aimTransitionSpeed, Time.deltaTime);
        aimPos.weight = currentAimWeight;
    }

    private void HandleFiring()
    {
        if (isFiring)
        {
            if (canFire && !isReloading)
            {
                Fire();
                canFire = false;
                StartCoroutine(FireCooldown());
            }
        }
    }

    private IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        canFire = true;
    }

    private void Fire()
    {
        animator.SetTrigger("Fire");
        Debug.Log("Shot Fired!");
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value) => lookInput = value.Get<Vector2>() / 100;
    public void OnRun(InputValue value)
    {
        isRunning = value.isPressed;
        targetRunMultiplier = isRunning ? 1.5f : 1f;
    }

    public void OnJump(InputValue value)
    {
        isJumping = value.isPressed;
        if (characterController.isGrounded)
        {
            verticalVelocity = isJumping ? jumpSpeed : -0.5f;
            if (isJumping)
            {
                animator.SetTrigger("Jump");
            }
        }
    }

    public void OnFire(InputValue value) => isFiring = value.isPressed;
    public void OnAim(InputValue value) => isAiming = !isAiming;
    public void OnReload(InputValue value)
    {
        if (!isReloading)
        {
            isReloading = true;
            rig.weight = 0f;
            animator.SetTrigger("Reload");
        }
    }

    public void SetJumpVelocity(float force)
    {
        moveDirection.y = force;
    }
}