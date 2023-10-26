using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage = 10;

    [SerializeField] public GameObject Wuser;

    private Animator Ani = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*PlayerStatus playerdamage = collision.gameObject.GetComponent<Playerstatus>();

         if (playerdamage != null)
         {
             playerdamage.DecreaseHP(damage);
         }*/
    }
        // Start is called before the first frame update
        void Start()
    {
        StartCoroutine(DelayCoroutine());

        Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float angle = GetAngle(this.transform.position, Wuser.transform.position);

        if (angle >= -135 && angle < -45)
        {
            Ani.SetInteger("Near Attack Int", 0);

            this.GetComponent<SpriteRenderer>().flipY = false;
        }

        if (angle >= 45 && angle < 135)
        {
            Ani.SetInteger("Near Attack Int", 0);

            this.GetComponent<SpriteRenderer>().flipY = true;
        }

        if (angle >= 135 || angle < -135)
        {
            Ani.SetInteger("Near Attack Int", 1);

            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (angle >= -45 && angle < 45)
        {
            Ani.SetInteger("Near Attack Int", 1);

            this.GetComponent<SpriteRenderer>().flipX = true;
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
