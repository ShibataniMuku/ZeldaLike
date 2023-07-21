using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Set : MonoBehaviour
{
    private bool firstPush = false;

    public void PressSetting()
    {
        Debug.Log("Press Setting");
        if (!firstPush)
        {
            Debug.Log("Go Next Scene!");
            SceneManager.LoadScene("");
            firstPush = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
