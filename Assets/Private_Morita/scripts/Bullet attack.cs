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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemystatus component = other.gameObject.GetComponent<Enemystatus>();

         if (component != null)
         {
            component.DecreaseHP(damage);
         }
        Debug.Log(other.gameObject.name);
       
      if(other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet")
            Destroy(this.gameObject);
    }
    
    
      
   
    
}
