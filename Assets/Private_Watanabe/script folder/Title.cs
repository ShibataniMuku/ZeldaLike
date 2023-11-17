using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Title : MonoBehaviour
{


    private bool firstPush = false;

    public void PressStart()
    { 
        Debug.Log("Press Start");
        if(!firstPush)
        {
            AudioManager.instance_AudioManager.PlaySE(4,1);
            AudioManager.instance_AudioManager.StopBGM();
            Debug.Log("Go Next Scene!");
            SceneManager.LoadScene("StageSelect");
            firstPush = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance_AudioManager.PlayBGM(4, 4);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
