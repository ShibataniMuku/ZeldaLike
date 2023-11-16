using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    private bool firstPush = false;
    // Start is called before the first frame update
    public void ToStageSelect()
    {
        if (firstPush==false)
        {
            AudioManager.instance_AudioManager.PlaySE(4, 1);
            AudioManager.instance_AudioManager.StopBGM();   
            SceneManager.LoadScene("StageSelect");
            firstPush = true;
        }
    }   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
