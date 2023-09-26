using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public int max;
    public int current;
    public Image curImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(max > 0)
        {
            if(current > max)
            {
                curImg.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
            else if(current < 0)
            {
                curImg.GetComponent<RectTransform>().localScale = new Vector3(0f, 1f, 1f);
            }
            else 
            {
                float hpRate = (float)current / (float)max;
                curImg.GetComponent<RectTransform>().localScale = new Vector3(hpRate, 1f,1f);
            }
        }
    }
}
