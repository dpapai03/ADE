using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GrabBottle : MonoBehaviour
{
    private float timer = 0f;
    public Transform RadialProgress;
    public Transform MyHead;
    public Rigidbody TheObject;
    private bool grabed = false;
    private Vector3 originalPos;
    private Quaternion originalRot;
    private GameObject apple;
    private GameObject newApple;
    public GameObject GVR;



    private GameObject canvas;
    private bool fromCollision = false;

   
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GrabBottle>().enabled = true;
        canvas = GameObject.Find("Canvas");
        RadialProgress.GetComponent<Image>().fillAmount = timer;
        originalPos = new Vector3(TheObject.transform.position.x, TheObject.transform.position.y, TheObject.transform.position.z);
        originalRot = TheObject.transform.rotation;
        apple = TheObject.gameObject;

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

    public void GrabTheObject()
    {

        TheObject.transform.parent = MyHead.transform;

    }

    
    //If there is a collision with the terrain set the bottle back to original position, if there is a collision with the flowers ignore it
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("terrain"))
        {
            fromCollision = true;
            Debug.Log("Collision");
        }
        else if (other.gameObject.CompareTag("Flower1") || other.gameObject.CompareTag("Flower2"))
        {
            Debug.Log("Flower Collision");
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), other, true);
        }
    }

    //If there is a collision with the terrain set the bottle back to original position and set the parrent of the bottle as null
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
            TheObject.transform.parent = null;
            TheObject.transform.position = originalPos;
            TheObject.gameObject.transform.rotation = Quaternion.Slerp(TheObject.transform.rotation, originalRot, Time.time * 1.0f);
            fromCollision = false;
        }
    }

}
