using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMouseLook : MonoBehaviour
{
    private float mouseX, mouseY, mouseZ = 0;

    void Start()
    {
        mouseX = transform.rotation.eulerAngles.y;
        mouseY = transform.rotation.eulerAngles.x;
        mouseZ = transform.rotation.eulerAngles.z;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            mouseX += Input.GetAxis("Mouse X") * 5;
            if(mouseX <= -180) { mouseX += 360; }
            else if(mouseX > 180) { mouseX -= 360; }
            mouseY += Input.GetAxis("Mouse Y") * 2.4f;
            if (mouseY <= -180) { mouseY += 360; }
            else if (mouseY > 180) { mouseY -= 360; }

        }

        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            mouseZ += Input.GetAxis("Mouse X") * 5;
            if (mouseZ <= -180) { mouseZ += 360; }
            else if (mouseZ > 180) { mouseZ -= 360; }
        }
        else
        {
            mouseZ = Mathf.Lerp(mouseZ, 0, Time.deltaTime / (Time.deltaTime + 0.1f));
        }
        transform.rotation = Quaternion.Euler(mouseY, mouseX, mouseZ);
    }
}
