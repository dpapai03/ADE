using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVRrotation : MonoBehaviour
{
    public Transform VRmainObject;
    public float cameraOffsetXZ;
    public float cameraOffsetY;
    public float bodyTurnAngle = 20f;
    public float animSpeed = 0.5f;

    private CharacterController MyCC;
    private Animator myAnim;
    private Vector3 vrRot, myRot;
    private Transform vrCamera;
    private float x, z;

    // Start is called before the first frame update
    void Start()
    {
        MyCC = GetComponent<CharacterController>();
        myAnim = GetComponent<Animator>();
        vrCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        vrRot = vrCamera.rotation.eulerAngles;
        myRot = transform.rotation.eulerAngles;

        float speed = MyCC.velocity.magnitude * animSpeed; 
        Debug.Log(speed);
        
        if(speed > 0.1f)
        {
            bodyTurnAngle = 5f;
        }
        else
        {
            bodyTurnAngle = 20f;
        }

        if (Mathf.DeltaAngle(vrRot.y, myRot.y) > bodyTurnAngle)
        {
            if (!gameObject.GetComponent<iTween>())
            {
                Debug.Log("Turn LEFT!");
                if (speed < 0.1f)
                {
                    myAnim.SetTrigger("TurnLeft");
                }
                if(speed > 0.1f)
                {
                    iTween.RotateTo(gameObject, new Vector3(myRot.x, vrRot.y, myRot.z), 0.5f);
                }
                else
                {
                    iTween.RotateTo(gameObject, new Vector3(myRot.x, vrRot.y, myRot.z), 1f);
                }
                
            }
        }
        else if (Mathf.DeltaAngle(vrRot.y, myRot.y) < -bodyTurnAngle)
        {
            if (!gameObject.GetComponent<iTween>())
            {
                Debug.Log("Turn RIGHT!");
                if (speed < 0.1f)
                {
                    myAnim.SetTrigger("TurnRight");
                }
                if (speed > 0.1f)
                {
                    iTween.RotateTo(gameObject, new Vector3(myRot.x, vrRot.y, myRot.z), 0.5f);
                }
                else
                {
                    iTween.RotateTo(gameObject, new Vector3(myRot.x, vrRot.y, myRot.z), 1f);
                }
            }
        }
        myAnim.SetFloat("Speed",speed);
     }

    void LateUpdate()
    {
        x = cameraOffsetXZ * Mathf.Sin(vrCamera.rotation.eulerAngles.y * Mathf.Deg2Rad);
        z = cameraOffsetXZ * Mathf.Cos(vrCamera.rotation.eulerAngles.y * Mathf.Deg2Rad);
        
        VRmainObject.position = transform.position + new Vector3(x, cameraOffsetY, z);
    }
}
