using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            SceneManager.LoadScene("Stage");
            Debug.Log("ok");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
