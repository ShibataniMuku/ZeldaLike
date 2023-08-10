using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Properties;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0; 
        scoreText.text = "Score"; 
       
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score.ToString();

    }
    
}
