using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pause : MonoBehaviour
{
   public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        Cursor.visible = false;
    }

    public void StageSelect()
    {
        
        SceneManager.LoadScene("StageSelect");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }
}
