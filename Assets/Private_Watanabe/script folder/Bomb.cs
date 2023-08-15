using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour
{
    public int bombNum;
    public TextMeshProUGUI bombText;

    // Start is called before the first frame update
    void Start()
    {
        bombText = GetComponent<TextMeshProUGUI>();
        bombNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bombText.text ="x"+bombNum.ToString();
    }
}
