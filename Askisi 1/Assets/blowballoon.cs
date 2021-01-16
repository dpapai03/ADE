using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowballoon : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            i++;
            if (i == 1)
            {
                part1.transform.position = new Vector3(26, 6, 49);
                part2.transform.position = new Vector3(26, 3, 49);
            }
            if (i == 2)
            {
                part1.transform.position = new Vector3(26, 4, 49);
                part2.transform.position = new Vector3(26, 1, 49);
            }
            if (i == 3)
            {
                i = 0;
                part1.transform.position = new Vector3(26, 8, 49);
                part2.transform.position = new Vector3(26, 5, 49);
            }

        }
    }
}
