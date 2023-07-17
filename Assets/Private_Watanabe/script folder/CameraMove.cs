using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    public GameObject SelectCam;
    public GameObject[] right;
    public GameObject[] left;
    public GameObject[] back;

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
        if(Input.GetMouseButtonDown(0))
        {
            foreach(GameObject Right in right) 
            {
                if(col == Right.GetComponent<Collider2D>())
                {
                    SelectCam.transform.position = new Vector3(this.transform.position.x + 40, this.transform.position.y, -10);
                }

            }
            foreach(GameObject Left in left)
            {
                if(col == Left.GetComponent<Collider2D>())
                    {
                    SelectCam.transform.position = new Vector3(this.transform.position.x - 40, this.transform.position.y, -10);
                      }
            }
            foreach(GameObject Back in back)
            {
                if(col == Back.GetComponent<Collider2D>())
                {
                    SceneManager.LoadScene("");
                }
            }
        }
    }
}
