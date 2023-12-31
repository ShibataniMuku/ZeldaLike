using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour
{
    public GameObject SelectCam;
    public GameObject[] title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = SelectCam.GetComponent<Camera>();
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Collider2D col = Physics2D.OverlapPoint(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject Title in title)
            {
                if (col == Title.GetComponent<Collider2D>())
                {
                    AudioManager.instance_AudioManager.PlaySE(4, 1);
                    AudioManager.instance_AudioManager.StopBGM();
                    SceneManager.LoadScene("Title");
                }
            }
            
        }

    }
}
