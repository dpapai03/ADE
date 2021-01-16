using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex1puzzleReveal : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;
    public GameObject p9;
    public GameObject p10;

    public scoreSet score;

    // Start is called before the first frame update
    void Start()
    {
        //p1.transform.localScale = new Vector3(0, 0, 0);
        //p2.transform.localScale = new Vector3(0, 0, 0);
        //p3.transform.localScale = new Vector3(0, 0, 0);
        //p4.transform.localScale = new Vector3(0, 0, 0);
        //p5.transform.localScale = new Vector3(0, 0, 0);
        //p6.transform.localScale = new Vector3(0, 0, 0);
        //p7.transform.localScale = new Vector3(0, 0, 0);
        //p8.transform.localScale = new Vector3(0, 0, 0);
        //p9.transform.localScale = new Vector3(0, 0, 0);
        //p10.transform.localScale = new Vector3(0, 0, 0);
        p1.gameObject.active = false;
        p2.gameObject.active = false;
        p3.gameObject.active = false;
        p4.gameObject.active = false;
        p5.gameObject.active = false;
        p6.gameObject.active = false;
        p7.gameObject.active = false;
        p8.gameObject.active = false;
        p9.gameObject.active = false;
        p10.gameObject.active = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            //p1.transform.localScale = new Vector3(1, 1, 1);
            p1.gameObject.active = true;
            score.increaseCount();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            //p2.transform.localScale = new Vector3(1, 1, 1);
            p2.gameObject.active = true;
            score.increaseCount();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            //  p3.transform.localScale = new Vector3(1, 1, 1);
            p3.gameObject.active = true;
            score.increaseCount();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            //  p4.transform.localScale = new Vector3(1, 1, 1);
            p4.gameObject.active = true;
            score.increaseCount();
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            //   p5.transform.localScale = new Vector3(1, 1, 1);
            p5.gameObject.active = true;
            score.increaseCount();
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            //  p6.transform.localScale = new Vector3(1, 1, 1);
            p6.gameObject.active = true;
            score.increaseCount();
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            // p7.transform.localScale = new Vector3(1, 1, 1);
            p7.gameObject.active = true;
            score.increaseCount();
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            //p8.transform.localScale = new Vector3(1, 1, 1);
            p8.gameObject.active = true;
            score.increaseCount();
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            //p9.transform.localScale = new Vector3(1, 1, 1);
            p9.gameObject.active = true;
            score.increaseCount();
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            // p10.transform.localScale = new Vector3(1, 1, 1);
            p10.gameObject.active = true;
            score.increaseCount();
        }

    }

    private void resetAss1()
    {
        p1.gameObject.active = false;
        p2.gameObject.active = false;
        p3.gameObject.active = false;
        p4.gameObject.active = false;
        p5.gameObject.active = false;
        p6.gameObject.active = false;
        p7.gameObject.active = false;
        p8.gameObject.active = false;
        p9.gameObject.active = false;
        p10.gameObject.active = false;
    }
}
