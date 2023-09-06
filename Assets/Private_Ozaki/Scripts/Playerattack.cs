using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    [SerializeField]
    int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        IDamegeable damegeable = collision.gameObject.GetComponent<IDamegeable>();

        if (damegeable != null)
        {
            damegeable.Damage(damage);
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
