using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowHide : MonoBehaviour
{
    public GameObject tick;
    private bool show = false;
    private int scene;
    private bool select = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (select)
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                manageScenes();
            }
        }
    }

    public void ShowAndHide()
    {
        if (!show)
        {
            tick.SetActive(true);
            show = true;
            select = true;
        }
        else
        {
            tick.SetActive(false);
            show = false;
            select = false;
        }
    }

    private void manageScenes()
    {
        switch (scene)
        {
            case 1:
                {
                    SceneManager.LoadScene(2);
                    break;
                }
            case 6:
                {
                    SceneManager.LoadScene(7);
                    break;
                }
            
                
        }
    }
}
