using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemLook : MonoBehaviour
{
    public Transform cameraRig;
    public float mouseSens;
    private float rigAngle = 0f;

    private bool isGameFocused = true;

    private void Start()
    {
        LockCursor();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        isGameFocused = hasFocus;
        if (hasFocus)
            LockCursor();
        else
            UnlockCursor();
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            isGameFocused = !isGameFocused;
            if (isGameFocused)
                LockCursor();
            else
                UnlockCursor();
        }
    }

    public void OnLookEvent(InputAction.CallbackContext context)
    {
        if (isGameFocused)
        {
            Look(context.ReadValue<Vector2>());
        }
    }

    private void OnLook(InputValue value)
    {
        print($"OnLook 호출 value : {value.Get<Vector2>()}");
        Vector2 mouseDelta = value.Get<Vector2>();
        Look(mouseDelta);
    }

    private void Look(Vector2 mouseDelta)
    {
        transform.Rotate(0f, mouseDelta.x * mouseSens * Time.deltaTime, 0f);
        rigAngle -= mouseDelta.y * mouseSens * Time.deltaTime;
        rigAngle = Mathf.Clamp(rigAngle, -90f, 90f);
        cameraRig.localEulerAngles = new Vector3(rigAngle, 0f, 0f);
    }

    // 커서 잠금 함수
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // 커서 잠금 해제 함수
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
