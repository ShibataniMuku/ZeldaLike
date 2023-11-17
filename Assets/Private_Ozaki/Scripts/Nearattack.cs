using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Nearattack : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    [SerializeField] private float moveSpeed = 3.0f;

    [SerializeField] public Transform targetPoint = null;

    private int index = 0;
    [SerializeField] private Transform[] route = new Transform[1];

    public GameObject player;

    public GameObject weapon;

    private Animator Anim = null;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        this.targetPoint = route[0];

        Anim = GetComponent<Animator>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);

        Vector2 dir = Vector2.zero;

        dir = (targetPoint.position - this.transform.position).normalized;

        Vector2 pos = this.transform.position;

        if (distance <= 5f)
        {
           targetPoint = player.transform;

            if(distance <= 2f)
            {
                moveSpeed = 0;
            }
        }
        else if (distance > 5f)
        {
            targetPoint = this.route[index];
        }

        if (Vector2.Distance(this.transform.position, targetPoint.position) <= 0.25f)
        {
            this.index++;

            if (index >= this.route.Length)
            {
                index = 0;
            }

            targetPoint = this.route[index];
        }

        if (this.moveSpeed <= 0 && isactiveCoroutine == false)
        {
            // コルーチンの起動
            StartCoroutine(DelayCoroutine(GetAngle(this.transform.position, targetPoint.position)));
        }

        float angle = GetAngle(this.transform.position, targetPoint.position);

        if (angle >= -135 && angle < -45)
        {
            

            if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                Anim.SetInteger("Attack Int", 1);
            }

            else
            {
                Anim.SetInteger("Walk int", 1);

                Anim.SetInteger("Attack Int", 0);
            }
        }

        if (angle >= 45 && angle < 135)
        {
            

            //Debug.Log("角度取得");

            if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                Anim.SetInteger("Attack Int", 2);
            }

            else
            {
                Anim.SetInteger("Walk int", 2);

                Anim.SetInteger("Attack Int", 0);
            }
        }

        if (angle >= 135 || angle < -135)
        {
           

            if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                Anim.SetInteger("Attack Int", 3);
            }

            else
            {
                Anim.SetInteger("Walk int", 3);

                Anim.SetInteger("Attack Int", 0);
            }
        }

        if (angle >= -45 && angle < 45)
        {
            

            if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                Anim.SetInteger("Attack Int", 4);
            }

            else
            {
                Anim.SetInteger("Walk int", 4);

                Anim.SetInteger("Attack Int", 0);
            }
        }
    }

    float GetAngle(Vector2 position, Vector2 targetPoint)
    {
        Vector2 dt = targetPoint - position;

        float rad = Mathf.Atan2(dt.y, dt.x);

        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }

    bool isactiveCoroutine = false;
    // コルーチン本体
    public IEnumerator DelayCoroutine(float rotation)
    {
        Debug.Log("呼び出し");

        isactiveCoroutine = true;

        GameObject w = Instantiate(weapon, this.transform.position + ((targetPoint.position - this.transform.position).normalized) * 1.25f, Quaternion.identity);

        w.GetComponent<Weapon>().Wuser = this.gameObject;

        yield return new WaitForSeconds(1f);

        moveSpeed = 3.0f;

        yield return new WaitForSeconds(1.1f);

        isactiveCoroutine = false;
    }
    private void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;

        // targetPointへのベクトルを取得し､directionに代入する処理を書く。

        direction = (targetPoint.position - this.transform.position).normalized;

        this.myRigidbody2D.velocity = direction * this.moveSpeed;
    }
}
