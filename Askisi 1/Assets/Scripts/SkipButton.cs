using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    private int scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNeckExercise()
    {
        SceneManager.LoadScene(3);
    }

    public void StartArmExercise()
    {
        SceneManager.LoadScene(8);
    }

    public void SkipAllArmExercises()
    {
        SceneManager.LoadScene(6);
    }
    public void SkipAllNeckExercises()
    {
        SceneManager.LoadScene(7);
    }
    public void SkipSetOfExercise()
    {
        switch (scene)
        {
            case 2:
                {
                    SceneManager.LoadScene(6);
                    break;
                }
            case 6:
                {
                    SceneManager.LoadScene(8);
                    break;
                }
            case 7:
                {
                    SceneManager.LoadScene(6);
                    break;
                }
        }
    }
    public void skipExercise()
    {
        switch (scene)
        {
            case 2:
                {
                    SceneManager.LoadScene(3);
                    break;
                }
            case 3:
                {
                    SceneManager.LoadScene(4);
                    break;
                }
            case 4:
                {
                    SceneManager.LoadScene(5);
                    break;
                }
            case 5:
                {
                    SceneManager.LoadScene(6);
                    break;
                }
            case 8:
                {
                    SceneManager.LoadScene(9);
                    break;
                }
            case 9:
                {
                    SceneManager.LoadScene(6);
                    break;
                }
        }
    }
    }
