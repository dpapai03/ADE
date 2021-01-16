using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRaiseCollision : MonoBehaviour
{
    private DeCastiljau ballScript;
    private bool backward = false;
    private GameObject gameManager;
    private float timer = 0;
    private bool startTime = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        ballScript = gameManager.GetComponent<DeCastiljau>();
        ballScript.StartExersice();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hands"))
        {
            Debug.Log("Collision Hands");
            //other.gameObject.GetComponent<Renderer>().material.color = Color.red;
            other.gameObject.GetComponent<AudioSource>().Play();
            ballScript.IncreaseCounter();
            if (!backward)
            {
                backward = true;
                ballScript.StartForward();
            }
            else
            {
                backward = false;
                ballScript.StartBackward();
               
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        
    }
}
