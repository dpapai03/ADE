using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ArmCompined : MonoBehaviour
{
    public GameObject thighs;
    public GameObject shoulders;
    public GameObject Sky;
    public TextMeshProUGUI text;
    public GameObject peach;
    private Vector3 origRot;
    private Vector3 basketpos1;
    private int count = 0;
    private bool sky = false;

    // Start is called before the first frame update
    void Start()
    {
        InitializeObjects();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();

        ChangeScene();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Thigh1") || collision.gameObject.CompareTag("Thigh2"))
        {
            Debug.Log("Collision Thighs");
            thighs.GetComponent<AudioSource>().Play();
            count++;
            EnableShoulders();
        }
        else if (collision.gameObject.CompareTag("Shoulder1") || collision.gameObject.CompareTag("Shoulder2"))
        {
            Debug.Log("Collision Shoulders");

            shoulders.GetComponent<AudioSource>().Play();
            count++;
            if (!sky)
            {
                sky = true;
                EnableSky();
                
            }
            else
            {
                sky = false;
                EnableThighs();
                
            }
        }

        else if (collision.gameObject.CompareTag("Sky1") || collision.gameObject.CompareTag("Sky2"))
        {
            Debug.Log("Collision Sky");

            thighs.GetComponent<AudioSource>().Play();
            count++;
            EnableShoulders();
        }
    }

    private void UpdateText()
    {
        text.text = count.ToString();
    }

    private void InitializeObjects()
    {
        thighs.transform.GetChild(0).gameObject.SetActive(true);
        thighs.transform.GetChild(1).gameObject.SetActive(true);
        shoulders.transform.GetChild(0).gameObject.SetActive(false);
        shoulders.transform.GetChild(1).gameObject.SetActive(false);
        Sky.transform.GetChild(0).gameObject.SetActive(false);
        Sky.transform.GetChild(1).gameObject.SetActive(false);

    }
    private void EnableThighs()
    {
        thighs.transform.GetChild(0).gameObject.SetActive(true);
        thighs.transform.GetChild(1).gameObject.SetActive(true);
        shoulders.transform.GetChild(0).gameObject.SetActive(false);
        shoulders.transform.GetChild(1).gameObject.SetActive(false);
        Sky.transform.GetChild(0).gameObject.SetActive(false);
        Sky.transform.GetChild(1).gameObject.SetActive(false);
    }

    private void EnableShoulders()
    {
        thighs.transform.GetChild(0).gameObject.SetActive(false);
        thighs.transform.GetChild(1).gameObject.SetActive(false);
        shoulders.transform.GetChild(0).gameObject.SetActive(true);
        shoulders.transform.GetChild(1).gameObject.SetActive(true);
        Sky.transform.GetChild(0).gameObject.SetActive(false);
        Sky.transform.GetChild(1).gameObject.SetActive(false);
    }

    private void EnableSky()
    {
        thighs.transform.GetChild(0).gameObject.SetActive(false);
        thighs.transform.GetChild(1).gameObject.SetActive(false);
        shoulders.transform.GetChild(0).gameObject.SetActive(false);
        shoulders.transform.GetChild(1).gameObject.SetActive(false);
        Sky.transform.GetChild(0).gameObject.SetActive(true);
        Sky.transform.GetChild(1).gameObject.SetActive(true);
    }

    private void ChangeScene()
    {
        if (count == 10)
        {
            SceneManager.LoadScene(6);
        }
    }
}
