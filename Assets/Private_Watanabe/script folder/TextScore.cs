using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        PlayerPrefs.GetInt("Score", score);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Total Score:" + score.ToString();
    }
}
