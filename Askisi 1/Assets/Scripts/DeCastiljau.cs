using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeCastiljau : MonoBehaviour
{
    private List<Vector3> points = new List<Vector3>();
    private List<Vector3> points1 = new List<Vector3>();
    private GameObject ball;
    private int ballCount = 10;
    public TextMeshProUGUI text;
    public GameObject canvas;
    private int counter = 0;
    private bool start = false;
    private Counter counterScript;
    // Use this for initialization
    void Start()
    {
        counterScript = GetComponent<Counter>();
        // Get all the children of the object Control Points
        ball = GameObject.FindGameObjectWithTag("butterfly");
        ball.GetComponent<CapsuleCollider>().enabled = false;
        GameObject controlPoints = GameObject.Find("Control Points");
        GameObject controlPoints1 = GameObject.Find("Control Points1");
        int children = controlPoints.transform.childCount;
        for (int i = 0; i < children; i++)
        {
            GameObject child = controlPoints.transform.GetChild(i).gameObject;
            GameObject child1 = controlPoints1.transform.GetChild(i).gameObject;
            if (child.activeSelf == true)
            {
                Transform point = child.transform;
                points.Add(point.position);
                Transform point1 = child1.transform;
                points1.Add(point1.position);
            }
        }
       
    }
    // Update is called once per frame
    void Update()
    {
      
            if (counter == 1)
            {
                canvas.SetActive(true);
                updateText();
            }
            if (counter > 1)
            {
                updateText();
            }
            ChangeScene();
        
    
  
    }
   
    
    IEnumerator StartBall()
    {
        
        ball.gameObject.SetActive(true);
        for (float u = 0f; u <= 1f; u += 0.004f)
        {
            ball.transform.position = BezierCurve.DeCasteljau(points.Count - 1, u, points);
            yield return null;
        }
        
        ball.GetComponent<CapsuleCollider>().enabled = true;

    }
    IEnumerator Forward()
    {
        
        ball.GetComponent<CapsuleCollider>().enabled = false;
        for (float u = 0f; u <= 1f; u += 0.004f)
        {
            ball.transform.position = BezierCurve.DeCasteljau(points1.Count - 1, u, points1);
            yield return null;
        }
        ball.GetComponent<CapsuleCollider>().enabled = true;

        


    }

    IEnumerator Backward()
    {
        
        ball.GetComponent<CapsuleCollider>().enabled = false;
        for (float u = 0f; u <= 1f; u += 0.004f)
        {
            ball.transform.position = BezierCurve.DeCasteljau(points.Count - 1, u, points);
            yield return null;
        }
        
        ball.GetComponent<CapsuleCollider>().enabled = true;
    }

    private void ChangeScene()
    {
        if (counter == ballCount)
        {
            SceneManager.LoadScene(9);
        }
    }
    void updateText()
    {

        text.text = counter.ToString();
    }

    public void StartExersice()
    {
        StartCoroutine(StartBall());
    }

    public void IncreaseCounter()
    {
        counter++;
    }

    public void StartForward()
    {
        StartCoroutine(Forward());
    }

    public void StartBackward()
    {
        StartCoroutine(Backward());
    }
}
