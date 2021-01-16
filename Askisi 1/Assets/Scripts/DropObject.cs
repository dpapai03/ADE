using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    public Rigidbody TheObject;
    // Start is called before the first frame update
    void Start()
    {
        TheObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
