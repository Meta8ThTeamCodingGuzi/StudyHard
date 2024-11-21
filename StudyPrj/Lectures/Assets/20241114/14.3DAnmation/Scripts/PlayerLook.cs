using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform cameraRig;

    public float mouseSens;

    public float rotationX = 0;
    
    public float rigAngle;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); //���콺 �������� delta (�������� ��ġ�� �� �������� ��ġ�� ���̰��� ����)
        float mouseY = Input.GetAxis("Mouse Y");

        //���콺�� �¿� �����ӿ� ���� ĳ������ transform�� Rotate
        transform.Rotate(0,mouseX * mouseSens * Time.deltaTime,0);

        
        rigAngle -= mouseY * mouseSens * Time.deltaTime;
        //ī�޶��� X�� ������ ����
        rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);
        //���ѵ� ������ŭ ī�޶��� rotation�� ����
        cameraRig.localEulerAngles = new Vector3(rigAngle,0f,0f);
    }
}
