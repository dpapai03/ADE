using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;

    private float i=0;

    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //cam1.enabled = !cam1.enabled;
            //cam2.enabled = !cam2.enabled;

            i++;
            if(i%3 == 0){
                cam1.enabled = true;
                cam2.enabled = false;
                cam3.enabled = false;
            }
            else
              if (i % 3 == 1)
            {
                cam1.enabled = false;
                cam2.enabled = true;
                cam3.enabled = false;
            }
            else
              if (i % 3 == 2)
            {
                cam1.enabled = false;
                cam2.enabled = false;
                cam3.enabled = true;
            }
        }
    }


}