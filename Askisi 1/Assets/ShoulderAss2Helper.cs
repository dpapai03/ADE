using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderAss2Helper : MonoBehaviour
{
    public GameObject leftMain;
    public GameObject rightMain;
    public GameObject leftchoice;
    public GameObject rightchoice;
    int i;

    // Start is called before the first frame update
    void Start()
    {
    leftMain.transform.localScale = new Vector3(0, 0, 0);
    rightMain.transform.localScale = new Vector3(0, 0, 0);
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            leftMain.transform.localScale = new Vector3(1, 1, 1);
            rightMain.transform.localScale = new Vector3(0, 0, 0);
            leftchoice.transform.localScale = new Vector3(0, 0, 0);
            rightchoice.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            leftMain.transform.localScale = new Vector3(0, 0, 0);
            rightMain.transform.localScale = new Vector3(1, 1, 1);
            leftchoice.transform.localScale = new Vector3(1, 1, 1);
            rightchoice.transform.localScale = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            leftMain.transform.localScale = new Vector3(0, 0, 0);
            rightMain.transform.localScale = new Vector3(0, 0, 0);
            leftchoice.transform.localScale = new Vector3(1, 1, 1);
            rightchoice.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
