using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class pathcreatorAss2 : MonoBehaviour
{
 
    public PathCreator pathCreator;
    public float speed = 1;
    float distanceTravelled;
    public GameObject hand;
    Renderer rend;
    public float maxDistance;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.blue);
    }

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);

        if (Vector3.Distance(hand.transform.position, this.transform.position) < maxDistance)
        {
            rend.material.SetColor("_Color", Color.red);
        }
        else
        {
            rend.material.SetColor("_Color", Color.blue);
        }
    }
}
