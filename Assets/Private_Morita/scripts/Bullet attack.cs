using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletattack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]
    int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemystatus component = collision.gameObject.GetComponent<Enemystatus>();

         if (component != null)
         {
            component.DecreaseHP(damage);
         }

        Destroy(this.gameObject);
    }
}
