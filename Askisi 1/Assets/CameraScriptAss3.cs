using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptAss3 : MonoBehaviour
{
    //float speed = 10.0f;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 230f;
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
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation = Mathf.Clamp(yRotation, 150f, 330f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

}
