using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptShoulderAss1 : MonoBehaviour
{
    //float speed = 10.0f;
    public float mouseSensitivityShoulder = 100f;
    float xRotationShoulder = 0f; 
    float yRotationShoulder = 0f;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityShoulder * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityShoulder * Time.deltaTime;

        xRotationShoulder -= mouseY;
        yRotationShoulder += mouseX;
        xRotationShoulder = Mathf.Clamp(xRotationShoulder, -90f, 90f);
        yRotationShoulder = Mathf.Clamp(yRotationShoulder, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotationShoulder, yRotationShoulder, 0f);
    }

}
