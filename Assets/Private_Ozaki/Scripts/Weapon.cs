using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public GameObject Wuser = null;

    private Animator Ani = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStatus playerdamage = collision.gameObject.GetComponent<PlayerStatus>();

         if (playerdamage != null)
         {
             playerdamage.decreaseHP(damage);
         }
    }
        // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCoroutine());

        Ani = GetComponent<Animator>();

        float angle = GetAngle(this.transform.position, Wuser.transform.position);

        if (angle >= -135 && angle < -45)
        {
            this.GetComponent<SpriteRenderer>().flipY = false;

            Ani.SetInteger("Near Attack Int", 2);
        }

        if (angle >= 45 && angle < 135)
        {
            this.GetComponent<SpriteRenderer>().flipY = true;

            Ani.SetInteger("Near Attack Int", 2);
        }

        if (angle >= 135 || angle < -135)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;

            Ani.SetInteger("Near Attack Int", 4);
        }

        if (angle >= -45 && angle < 45)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;

            Ani.SetInteger("Near Attack Int", 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Wuser == null) 
        { 
            Destroy(this.gameObject);
            
            return;
        }
       /*  float angle = GetAngle(this.transform.position, Wuser.transform.position);

        if (angle >= -135 && angle < -45)
        {
            this.GetComponent<SpriteRenderer>().flipY = false;

            Ani.SetInteger("Near Attack Int", 2);
        }

        if (angle >= 45 && angle < 135)
        {
            this.GetComponent<SpriteRenderer>().flipY = true;

            Ani.SetInteger("Near Attack Int", 2);
        }

        if (angle >= 135 || angle < -135)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;

            Ani.SetInteger("Near Attack Int", 4);
        }

        if (angle >= -45 && angle < 45)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;

            Ani.SetInteger("Near Attack Int", 1);
        }*/
    }

    float GetAngle(Vector2 position, Vector2 targetPoint)
    {
        Vector2 dt = targetPoint - position;

        float rad = Mathf.Atan2(dt.y, dt.x);

        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(0.8f);

        Destroy(this.gameObject);
    }
}
