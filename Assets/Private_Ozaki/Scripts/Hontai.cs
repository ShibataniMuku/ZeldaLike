using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hontai : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D myRigidbody2D = null;

    public float power = 1f;

    [SerializeField]
    int damage = 10;

    private Animator Anim = null;

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
        this.myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        //transform.DOMove(player.transform.position, 1f).SetEase(Ease.Linear).SetLoops(1, LoopType.Yoyo);

        StartCoroutine(DelayCoroutine());

        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        /*float angle = GetAngle(this.transform.position, player.transform.position);

        if (angle >= -135 && angle < -45)
        {
            Anim.SetInteger("Rush Int", 0);
        }

        if (angle >= 45 && angle < 135)
        {
            Anim.SetInteger("Rush Int", 1);
        }

        if (angle >= 135 || angle < -135)
        {
            Anim.SetInteger("Rush Int", 2);
        }

        if (angle >= -45 && angle < 45)
        {
            Anim.SetInteger("Rush Int", 3);
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
        while (true)
        {
            if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                float angle = GetAngle(this.transform.position, player.transform.position);

                yield return new WaitForSeconds(0.5f);

                if (angle >= -135 && angle < -45)
                {
                    Anim.SetInteger("Rush Int", 0);
                }

                if (angle >= 45 && angle < 135)
                {
                    Anim.SetInteger("Rush Int", 1);
                }

                if (angle >= 135 || angle < -135)
                {
                    Anim.SetInteger("Rush Int", 2);

                    this.GetComponent<SpriteRenderer>().flipX = true;
                }

                if (angle >= -45 && angle < 45)
                {
                    Anim.SetInteger("Rush Int", 3);

                    this.GetComponent<SpriteRenderer>().flipX = false;
                }

                //transform.DOMove(player.transform.position, 1f).SetEase(Ease.Linear).SetLoops(1, LoopType.Yoyo);
                myRigidbody2D.AddForce((player.transform.position - this.transform.position).normalized * power, ForceMode2D.Impulse);
               // Debug.Log("aa");
            }

            else if (Vector2.Distance(this.transform.position, player.transform.position) > 3f)
            {
                GetComponent<Rush>().enabled = true;

                enabled = false;
            }

            yield return new WaitForSeconds(1f);

            myRigidbody2D.velocity = Vector2.zero;
        }

    }
   
}
