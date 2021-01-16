using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass1BallJump : MonoBehaviour
{

    public GameObject bal;
    public scoreSet score;
    Rigidbody ball;

    // Start is called before the first frame update
    void Start()
    {

        ball = bal.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x -= 0.02f;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x += 0.02f;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.y += 0.02f;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y -= 0.02f;
            this.transform.position = position;
        }


        if (this.transform.position.y > 7.5)
        {
   
            Vector3 throwB = new Vector3(0f, 1f, 1f);

            ball.velocity = ball.velocity + throwB;
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            ball.transform.position = new Vector3(-51, 8, 63);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            score.increaseCount();
        }
    }
}

