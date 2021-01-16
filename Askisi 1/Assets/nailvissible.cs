using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailvissible : MonoBehaviour
{
    public GameObject nail1;
    public GameObject nail2;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        nail1.gameObject.active = true;
        nail2.gameObject.active = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("i=" + i);
            if (i%2==0)
            {
                Debug.Log("alo");
                nail1.gameObject.active = false;
                nail2.gameObject.active = true;
                i++;
            }
            else
            {
                Debug.Log("bye");
                nail1.gameObject.active = true;
                nail2.gameObject.active = false;
                i++;
            }
        }



    }
}
