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