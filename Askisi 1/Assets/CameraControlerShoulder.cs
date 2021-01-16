using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlerShoulder : MonoBehaviour
{
    public Camera cam1s;
    public Camera cam2s;
    public Camera cam3s;

    private float i = 0;

    void Start()
    {
        cam1s.enabled = true;
        cam2s.enabled = false;
        cam3s.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //cam1.enabled = !cam1.enabled;
            //cam2.enabled = !cam2.enabled;

            i++;
            if (i % 3 == 0)
            {
                cam1s.enabled = true;
                cam2s.enabled = false;
                cam3s.enabled = false;
            }
            else
              if (i % 3 == 1)
            {
                cam1s.enabled = false;
                cam2s.enabled = true;
                cam3s.enabled = false;
            }
            else
              if (i % 3 == 2)
            {
                cam1s.enabled = false;
                cam2s.enabled = false;
                cam3s.enabled = true;
            }
        }
    }


}