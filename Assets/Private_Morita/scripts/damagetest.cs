using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagetest : MonoBehaviour
{
    
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    [SerializeField]
    int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStatus playerdamage = collision.gameObject.GetComponent<PlayerStatus>();

        if (playerdamage != null)
        {
            playerdamage.decreaseHP(damage);
        }

       
    }
}
