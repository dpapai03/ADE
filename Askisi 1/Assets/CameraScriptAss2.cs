using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptAss2 : MonoBehaviour
{
    //float speed = 10.0f;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 180f;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -140f, 50f);
        yRotation = Mathf.Clamp(yRotation, 90f, 270f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

}
