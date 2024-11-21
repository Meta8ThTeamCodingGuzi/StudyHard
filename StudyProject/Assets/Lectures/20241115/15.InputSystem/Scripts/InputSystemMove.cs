using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(Animator), typeof(PlayerInput))]
public class InputSystemMove : MonoBehaviour
{
    private CharacterController charCtrl;
    private Animator animator;

    public float walkSpeed;
    public float runSpeed;
    
    private Vector2 inputValue;

    private InputAction moveAction;
    public InputActionAsset controlDefine;

    private void Awake()
    {
        charCtrl = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        controlDefine = GetComponent<PlayerInput>().actions;
        moveAction = controlDefine.FindAction("Move");
    }

    private void OnEnable()
    {
        //moveAction.started -> XXDown
        moveAction.performed += OnMoveEvent; // XX
        moveAction.canceled += OnMoveEvent; // XXUp
    }

    private void OnDisable()
    {
        moveAction.performed -= OnMoveEvent;
        moveAction.canceled -= OnMoveEvent;
    }

    public void OnMoveEvent(InputAction.CallbackContext context) 
    {
        inputValue = context.ReadValue<Vector2>();
        print($"OnMoveEvent : {inputValue}");
    }
        
    private void OnMove(InputValue value) 
    {
        inputValue = value.Get<Vector2>();
        print($"OnMove 호출됨 파라미터 : {inputValue}");
    }

    private void Update()
    {
        Vector3 inputMoveDir = new Vector3(inputValue.x , 0f , inputValue.y) * walkSpeed;
        Vector3 actualMoveDir = transform.TransformDirection(inputMoveDir);

        charCtrl.Move(actualMoveDir * Time.deltaTime);

        animator.SetFloat("Xdir", inputValue.x);
        animator.SetFloat("Ydir", inputValue.y);
        animator.SetFloat("Speed", inputValue.magnitude);
    }
}
