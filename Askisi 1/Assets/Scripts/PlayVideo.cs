using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject GVR;
    private bool start = false;
    private float timer = 0;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;
            if (timer >= videoPlayer.clip.length)
            {
                videoPlayer.Stop();
                GVR.GetComponent<GvrReticlePointer>().enabled = true;
                timer = 0;
                start = false;
            }
        }
    }

    public void PlayButton()
    {
        start = true;
        videoPlayer.Play();
       GVR.GetComponent<GvrReticlePointer>().enabled = false;
        //videoPlayer.loopPointReached += EndReached;

    }

}
