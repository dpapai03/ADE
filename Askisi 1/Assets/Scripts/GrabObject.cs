using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GrabObject : MonoBehaviour
{
    private float timer = 0f;
    public Transform RadialProgress;
    public Transform MyHead;
    public Rigidbody TheObject;
    private bool grabed = false;
    private Vector3 originalPos;
    private GameObject apple;
    private GameObject newApple;
    public GameObject GVR;
    public static int counter = 0;
    public TextMeshProUGUI text;
    private GameObject canvas;
    private bool fromCollision = false;
    private Quaternion originalRot;
    public GameObject app;
    private Vector3 basketPosition;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GrabObject>().enabled = true;
        canvas = GameObject.Find("Canvas");
        RadialProgress.GetComponent<Image>().fillAmount = timer ;
        originalPos = new Vector3(TheObject.transform.position.x,TheObject.transform.position.y, TheObject.transform.position.z);
        apple = TheObject.gameObject;
        originalRot = TheObject.transform.rotation;
        basketPosition = new Vector3(-20.9f, 1.6f, -14f);


    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        RadialProgress.GetComponent<Image>().fillAmount = timer / 2;

        if (timer >= 2f)
        {
           GrabTheObject();
        }
   
        //If the task is complete load the next scene
        if (counter == 10)
        {
            SceneManager.LoadScene(6);
        }

        //If there was collision with terrain put the apple back to tree
        if (fromCollision)
        {
            TheObject.transform.parent = null;
            TheObject.transform.position = originalPos;
            TheObject.gameObject.transform.rotation = Quaternion.Slerp(TheObject.transform.rotation, originalRot, Time.time * 1.0f);
            fromCollision = false;
        }
    }

    public void ResetInator()
    {
        timer = 0f;
        RadialProgress.GetComponent<Image>().fillAmount = timer;
        

    }

    //Set the apple as child of the camera
    public void GrabTheObject()
    {

        TheObject.transform.parent = MyHead.transform;
      
    }

    //Update the counter showed on canvas
    void updateText()
    {
        text.text = counter.ToString();
    }

    //Check for collision with basket and put the apple in the basket
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("basket"))
        {
            timer = 0f;
            Instantiate(app, basketPosition, originalRot);
            RadialProgress.GetComponent<Image>().fillAmount = timer;
            TheObject.gameObject.GetComponent<Collider>().enabled = false;
            TheObject.isKinematic = true;
            TheObject.transform.parent = null;
            TheObject.transform.position = originalPos;
            TheObject.transform.rotation = Quaternion.Slerp(TheObject.transform.rotation, originalRot, Time.time * 1.0f);
            basketPosition = new Vector3(basketPosition.x, basketPosition.y, basketPosition.z + 1);
            TheObject.gameObject.GetComponent<Collider>().enabled = true;
            counter++;
            updateText();
            if (counter == 5)
            {
                basketPosition = new Vector3(-22f, 1.3f, -14);
            }
            grabed = false;
            Debug.Log("Basket");
        }
        if (other.gameObject.CompareTag("terrain"))
        {
            fromCollision = true;
            Debug.Log("Terrain");
            
        }

    }
   
   
}
