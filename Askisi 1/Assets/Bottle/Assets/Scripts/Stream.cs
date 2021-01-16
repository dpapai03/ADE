using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    private LineRenderer lineRenderer = null;
    private Vector3 targetPosition = Vector3.zero;
    public bool f1=false;
    public bool f2=false;
    
    // private ParticleSystem splashParticle = null;


    private Coroutine PourRoutine = null; 

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
       // splashParticle = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
    }

    public void Begin()
    {
      //  StartCoroutine(UpdateParticle());
        PourRoutine = StartCoroutine(BeginPour());
    }

    private IEnumerator BeginPour()
    {
        while (gameObject.activeSelf)
        {
            targetPosition = FindEndPoint();
            MoveToPosition(0, transform.position);
            AnimateToPosition(1, targetPosition);
            yield return null;
        }
    }

    public void End()
    {
        StopCoroutine(PourRoutine);
        PourRoutine = StartCoroutine(EndPour());
    }

    private IEnumerator EndPour()
    {
        while (!HasReachedPosition(0, targetPosition))
        {
            AnimateToPosition(0, targetPosition);
            AnimateToPosition(1, targetPosition);
            yield return null;
        }
        
        Destroy(gameObject);
        
    }
    private Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out hit, 4.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);
        //RaycastHit hit;
        //Ray ray = new Ray(transform.position, Vector3.down);
        //Physics.Raycast(ray, out hit, 4.0f);
        Debug.DrawRay(transform.position, Vector3.down * 4.0f);
        if (Physics.Raycast(ray, out hit, 4.0f))
        {
            if (hit.collider.tag == "Flower1")
            {
                Debug.Log("Find collision");
                f1 = true;
                f2 = false;
            }
            if (hit.collider.tag == "Flower2")
            {
                f2 = true;
                f1 = false;
                Debug.Log("Find collision1");
            }
        }
        endPoint = new Vector3(endPoint.x, endPoint.y - 1, endPoint.z);
        Debug.Log(endPoint);
        return endPoint;
    }

    private void MoveToPosition(int index, Vector3 targetPosition)
    {
        lineRenderer.SetPosition(index, targetPosition);
    }

    private void AnimateToPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPoint = lineRenderer.GetPosition(index);
        Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);
        lineRenderer.SetPosition(index, newPosition);
    }
    private bool HasReachedPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPosition = lineRenderer.GetPosition(index);
        return currentPosition == targetPosition;
    }

    private IEnumerator UpdateParticle()
    {
        while (gameObject.activeSelf)
        {
           // splashParticle.gameObject.transform.position = targetPosition;
            bool isHitting = HasReachedPosition(1, targetPosition);
           // splashParticle.gameObject.SetActive(isHitting);
            yield return null;
        }
    }
}
