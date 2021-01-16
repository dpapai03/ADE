using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float counter = 6;
    private int timer = 6;
    public TextMeshProUGUI text;
    public GameObject canvas;
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        //text.text = timer.ToString();
       // canvas.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            counter -= (int)1 * Time.deltaTime;
            timer = (int)counter;
            // seconds =(int) counter % 60;
            if (counter >= 0)
            {
                updateText();
            }
            else
            {
                canvas.SetActive(false);
            }
        }
    }

    void updateText()
    {

        text.text = timer.ToString();
    }

    public void StartCount()
    {
        start = true;
        canvas.SetActive(true);
    }

}
