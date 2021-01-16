using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderAss1Movement : MonoBehaviour
{

    public GameObject leftBreak;
    public GameObject rightBreak;
    Renderer rendLB,rendRB;
    
    // Start is called before the first frame update
    void Start()
    {
        rendLB = leftBreak.GetComponent<Renderer>();
        rendRB = rightBreak.GetComponent<Renderer>();
        rendLB.material.SetColor("_Color", Color.blue);
        rendRB.material.SetColor("_Color", Color.blue);
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
            //position.y++;
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
            rendLB.material.SetColor("_Color", Color.red);
            rendRB.material.SetColor("_Color", Color.red);
        }
        else
        {
            rendLB.material.SetColor("_Color", Color.blue);
            rendRB.material.SetColor("_Color", Color.blue);
        }

    }
}
