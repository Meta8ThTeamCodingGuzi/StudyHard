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
        float mouseX = Input.GetAxis("Mouse X"); //마우스 움직임의 delta (전프레임 위치와 현 프레임의 위치의 차이값의 보간)
        float mouseY = Input.GetAxis("Mouse Y");

        //마우스의 좌우 움직임에 맞춰 캐릭터의 transform을 Rotate
        transform.Rotate(0,mouseX * mouseSens * Time.deltaTime,0);

        
        rigAngle -= mouseY * mouseSens * Time.deltaTime;
        //카메라릭의 X축 각도를 제한
        rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);
        //제한된 각도만큼 카메라릭의 rotation을 변경
        cameraRig.localEulerAngles = new Vector3(rigAngle,0f,0f);
    }
}
