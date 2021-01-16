using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject exitPanel;

    // Use this for initialization
    void Start()
    {
        mainMenuPanel.SetActive(true);
        exitPanel.SetActive(false);

    }



    public void StartGameClick()
    {
        SceneManager.LoadScene(1);

    }


    public void ExitClicked()
    {
        exitPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void NoClicked()
    {
        mainMenuPanel.SetActive(true);
        exitPanel.SetActive(false);
    }

    public void YesGameClick()
    {
        Application.Quit();
    }
}
