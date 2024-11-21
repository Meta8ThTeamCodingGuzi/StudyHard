using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController),typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    #region Private Components
    private CharacterController charCtrl;
    private Animator animator;
    #endregion

    #region Public Fields
    public float walkSpeed;
    public float runSpeed;
    #endregion

    #region Private Fields
    private float currentSpeed;
    #endregion

    private void Awake()
    {
        charCtrl = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 inputValue = Vector3.zero;

        inputValue.x = Input.GetAxis("Horizontal");
        inputValue.z = Input.GetAxis("Vertical");

        inputValue = Vector3.ClampMagnitude(inputValue, 1);

        float runValue = Input.GetAxis("Fire3");
                        //내 캐릭터가 걷고 있을 때의 속도     +   내 캐릭터가 뛰고 있을때 속도
        currentSpeed = (inputValue.magnitude * walkSpeed) + (runValue * (runSpeed - walkSpeed));

        Vector3 inputMoveDir = inputValue * currentSpeed;

        Vector3 actualMoveDir = transform.TransformDirection(inputMoveDir);

        charCtrl.Move(actualMoveDir * Time.deltaTime);
    }
}