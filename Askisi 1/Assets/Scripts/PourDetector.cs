using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 0;
    public Transform origin = null;
    public GameObject StreamPrefab = null;
    public TextMeshProUGUI text;
    public GameObject flower1 = null;
    public GameObject flower2 = null;

    private bool isPouring = false;
    private Stream currentStream = null;
    private static int counter = 0;
    private bool left = false;
    private bool right = false;
    private float leftTimer = 0;
    private float rightTimer = 0;

    private void Start()
    {
        
    }
    private void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;
        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                
                StarPour();
                right = currentStream.f1;
                left = currentStream.f2;
            }
            else
            {
                
                EndPour();
               // counter++;
               // updateText();

            }
        }
        if (counter == 9)
        {
            flower1.SetActive(true);
            flower2.SetActive(true);
        }
        if (counter == 10)
        {
            SceneManager.LoadScene(4);
        }
        if (left)
        {
            leftTimer += Time.deltaTime;
            if (leftTimer >= 3)
            {
                leftTimer = 0;
                left = false;
                flower2.transform.localScale += new Vector3(0.6f, 0.6f, 0.6f);
                counter++;
                updateText();
            }
        }
        if (right)
        {
            rightTimer += Time.deltaTime;
            if (rightTimer > 3)
            {
                rightTimer = 0;
                right = false;
                flower1.transform.localScale += new Vector3(0.6f, 0.6f, 0.6f);
                counter++;
                updateText();
            }
        }
    }


    private void StarPour()
    {
        print("start");
        currentStream = CreateStream();
        currentStream.Begin();
    }

    private void EndPour()
    {
        print("end");
        currentStream.End();
        currentStream = null;
    }

    void updateText()
    {
        text.text = counter.ToString();
    }
    private float CalculatePourAngle()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(StreamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left"))
        {
            left = true;
            right = false;
            Debug.Log("Left");
        }
       else if (other.CompareTag("Right"))
        {
            right = true;
            left = false;
            Debug.Log("Right");
        }
    }
}