using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CountDown : MonoBehaviour
{
    public static float CountDownTime;
    public TextMeshProUGUI CountDownText;
    // Start is called before the first frame update
    void Start()
    {
        CountDownTime = 60.0F;
    }

    // Update is called once per frame
    void Update()
    {
        CountDownText.text = String.Format("Time:{0:00.00}", CountDownTime);
        CountDownTime -= Time.deltaTime;
        if (CountDownTime <= 0.0F)
        {
            CountDownTime = 0.0F;
        }
    }
}
