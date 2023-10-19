using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    [SerializeField] private float moveSpeed = 3.0f;

    public Transform targetPoint = null;

    private int index = 0;
    [SerializeField] private Transform[] route = new Transform[1];

    public GameObject player;

    private Animator Anim = null;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        this.targetPoint = route[0];

        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance <= 5f)
        {
            targetPoint = player.transform;

            if(distance <= 3f)
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
            // �R���[�`���̋N��
            StartCoroutine(DelayCoroutine());
        }

        float angle = GetAngle(this.transform.position, targetPoint.position);

        if(angle >= -135 &&  angle < -45)
        {
            Anim.SetInteger("Walk int", 1);

            if(Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                Anim.SetInteger("Attack Int", 1);
            }
        }

        if(angle >= 45 &&  angle < 135)
        {
            Anim.SetInteger("Walk int", 2);

            if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                Anim.SetInteger("Attack Int", 2);
            }
        }

        if(angle >= 135 || angle < -135)
        {
            Anim.SetInteger("Walk int", 3);

            if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                Anim.SetInteger("Attack Int", 3);
            }
        }

        if (angle >= -45 && angle < 45)
        {
            Anim.SetInteger("Walk int", 4);

            if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                Anim.SetInteger("Attack Int", 4);
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
    // �R���[�`���{��
    private IEnumerator DelayCoroutine()
    {
        Debug.Log("�Ăяo��");

        isactiveCoroutine = true;

        yield return new WaitForSeconds(1f);

        moveSpeed = 3.0f;

        yield return new WaitForSeconds(1.1f);

        isactiveCoroutine = false;
    }
    private void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;

        // targetPoint�ւ̃x�N�g�����擾���direction�ɑ�����鏈���������B

        direction = (targetPoint.position - this.transform.position).normalized;

        this.myRigidbody2D.velocity = direction * this.moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}