using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreSet : MonoBehaviour
{
     
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMesh>().text = count.ToString();
    }

    public void increaseCount()
    {
        count++;
    }

    public void decreaseCount()
    {
        count--;
    }
}
