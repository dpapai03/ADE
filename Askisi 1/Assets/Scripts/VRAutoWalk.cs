using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAutoWalk : MonoBehaviour
{
    public float speed = 3.0F;
    private bool moveForward;
    private CharacterController myCC;
    private Transform vrCamera; 

    // Start is called before the first frame update
    void Start()
    {
       myCC = GetComponent<CharacterController>();
        vrCamera = Camera.main.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            moveForward = !moveForward;
            if(moveForward == false)
            {
                myCC.SimpleMove(Vector3.zero);
            }
        }
        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            myCC.SimpleMove(forward * speed);
        }
    }
}
