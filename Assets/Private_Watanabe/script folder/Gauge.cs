using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public int max;
    public int HP;
    private PlayerStatus playerStatus;
    public Image curImg;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        HP = playerStatus.GetHP();

        if(max > 0)
        {
            if(HP > max)
            {
                curImg.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
            else if(HP < 0)
            {
                curImg.GetComponent<RectTransform>().localScale = new Vector3(0f, 1f, 1f);
            }
            else 
            {
                float hpRate = (float)HP / (float)max;
                curImg.GetComponent<RectTransform>().localScale = new Vector3(hpRate, 1f,1f);
            }
        }
    }
}
