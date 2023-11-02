using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class TextTime : MonoBehaviour
{
    private TextMeshProUGUI clearText;
    private int clearTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        clearText = GetComponent<TextMeshProUGUI>();
        PlayerPrefs.GetInt("ClearTime",clearTime );
    }

    // Update is called once per frame
    void Update()
    {
        clearText.text = "Clear Time:" + clearTime.ToString();
    }
}
