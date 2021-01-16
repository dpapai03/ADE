using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class tennisball : MonoBehaviour
{
    public Camera cam;
    public Rigidbody mybody;
    private bool hashit = false;
    public float shootForce = 20f;
    public scoreSet score;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hashit)
        {
            transform.rotation = Quaternion.LookRotation(mybody.velocity);
            mybody.useGravity = true;
            mybody.velocity = cam.transform.right * shootForce;
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            mybody.useGravity = false;
            hashit = false;
            mybody.velocity = Vector3.zero;
            transform.position = new Vector3(-16, 8, 6);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "raket")
        {
            hashit = true;
            Debug.Log("rakethit");
            score.increaseCount();
        }
    }
}
