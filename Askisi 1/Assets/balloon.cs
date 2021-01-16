using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour
{
    //public GameObject balloonpop;
    public int st;
    public ParticleSystem pop;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x + st; // your new value.
            scale.y = scale.y + st;
            scale.z = scale.z + st;
            transform.localScale = scale;

            if (scale.x > 10)
            {
                Instantiate(pop, transform.position, Quaternion.identity);
                scale.x = 1; // your new value.
                scale.y = 1;
                scale.z = 1;
                transform.localScale = scale;

            }
                 
        }
    }
}
