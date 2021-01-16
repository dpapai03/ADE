using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoAss1 : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoplayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (videoplayer.isPaused)
            {
                videoplayer.Play();
            }
            else
            {
                videoplayer.Pause();
            }
        }

    }
}
