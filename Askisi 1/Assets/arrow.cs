using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Rigidbody mybody;
    public scoreSet score;
    private bool hashit = false;
 

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
        StartCoroutine("UpdateVelocity");
    }

    // Update is called once per frame
    IEnumerator UpdateVelocity()
    {
        while (!hashit)
        {
            transform.rotation = Quaternion.LookRotation(mybody.velocity);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "target")
        {
            hashit = true;
            scoreInc();
            stick();
        }
    }

    private void stick()
    {
        Destroy(mybody);
        Destroy(GetComponent<Collider>());
    }

    private void scoreInc()
    {
        score.increaseCount();
    }
}
