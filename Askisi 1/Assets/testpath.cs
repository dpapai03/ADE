using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public class testpath : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction reverse=EndOfPathInstruction.Reverse;
    public EndOfPathInstruction stop = EndOfPathInstruction.Stop;
    public float speed = 1;
    float distanceTravelled;

    void Start()
    {
        StartCoroutine(WaitTimeTest);
    }


    void Update()
    {

        distanceTravelled += speed * Time.deltaTime;
        
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, stop);
        StartCoroutine(WaitTimeTest);
        //print(pathCreator.path.GetPoint(1).ToString);
        //transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, reverse);



    }
/*
    private void print(Func<string> toString)
    {
        throw new NotImplementedException();
    }
*/
    IEnumerator WaitTimeTest
    {
        get
        {
            yield return new WaitForSecondsRealtime(3);
            Debug.Log("Wait 3 seconds");
        }
    }
}
