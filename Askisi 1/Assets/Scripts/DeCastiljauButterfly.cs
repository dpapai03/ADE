using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeCastiljauButterfly : MonoBehaviour
{
    private List<Vector3> points = new List<Vector3>();
    private List<Vector3> points1 = new List<Vector3>();
    private List<Vector3> points2 = new List<Vector3>();
    private int butterflyCount = 10;
    private GameObject butterfly;
    private int counter = 0;
    private bool start = false;
    private Counter counterScript;

    public TextMeshProUGUI text;
    public GameObject canvas;



    // Use this for initialization
    void Start()
    {
        counterScript = GetComponent<Counter>();
        text.text = counter.ToString();
        GetComponent<DeCastiljauButterfly>().enabled = true;
        butterfly = GameObject.FindGameObjectWithTag("butterfly");
        butterfly.gameObject.SetActive(false);
        // Get all the children of the object Control Points
        GameObject controlPoints = GameObject.Find("Control Points");
        GameObject controlPoints1 = GameObject.Find("Control Points1");
        GameObject controlPoints2 = GameObject.Find("Control Points2");
        int children = controlPoints.transform.childCount;
        int children2 = controlPoints2.transform.childCount;
        for (int i = 0; i < children; i++)
        {
            GameObject child = controlPoints.transform.GetChild(i).gameObject;
            GameObject child1 = controlPoints1.transform.GetChild(i).gameObject;

            //GameObject child1 = controlPoints1.transform.GetChild(i).gameObject;
            if (child.activeSelf == true)
            {
                Transform point = child.transform;
                points.Add(point.position);
                Transform point1 = child1.transform;
                points1.Add(point1.position);
            }
        }
        for (int i = 0; i < children2; i++)
        {
            GameObject child2 = controlPoints2.transform.GetChild(i).gameObject;
            if (child2.activeSelf == true)
            {
                Transform point2 = child2.transform;
                points2.Add(point2.position);
            }
        }
        //Debug.Log("Start" + Time.deltaTime);
        //StartCoroutine(StartButterfly());
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

    IEnumerator StartButterfly()
    {
        yield return new WaitForSecondsRealtime(6);
        butterfly.gameObject.SetActive(true);
        for (float u = 0f; u <= 1f; u += 0.004f)
        {
            butterfly.transform.position = BezierCurve.DeCasteljau(points2.Count - 1, u, points2);
            yield return null;
        }
       StartCoroutine(Forward());
       
    }
    IEnumerator Forward()
    {
        counter++;
        yield return new WaitForSecondsRealtime(3);
        for (float u = 0f; u <= 1f; u += 0.002f)
        {
            Debug.Log(butterfly.name);
            butterfly.transform.position = BezierCurve.DeCasteljau(points.Count - 1, u, points);
            yield return null;
        }
        start = true;
        
            StartCoroutine(Backward());
       
        
    }

    IEnumerator Backward()
    {
        counter++;
        yield return new WaitForSecondsRealtime(3);
        for (float u = 0f; u <= 1f; u += 0.002f)
        {
            Debug.Log(butterfly.name);
            butterfly.transform.position = BezierCurve.DeCasteljau(points1.Count - 1, u, points1);
            yield return null;
        }
        StartCoroutine(Forward());
    }

    private void ChangeScene()
    {
        if (counter == butterflyCount)
        {
            SceneManager.LoadScene(5);
        }
    }
    void updateText()
    {

        text.text = counter.ToString();
    }

    public void StartExersice()
    {
        counterScript.StartCount();
        StartCoroutine(StartButterfly());
    }

    
}
     
