using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");
        float xSpeed = 0.0f;
        float ySpeed = 0.0f;
        if (horizontalKey > 0)
        {
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            xSpeed = -speed;
        }
        else if (verticalKey > 0) 
        {
            ySpeed = speed;
        }
        else if(verticalKey < 0) 
        {
            ySpeed = -speed;
        }
        else
        {
            xSpeed = 0.0f;
            ySpeed = 0.0f;
        }
        rb.velocity = new Vector2 (xSpeed, ySpeed);
    }
}
