using DG.Tweening;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Rush : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    [SerializeField] private float moveSpeed = 3.0f;

    [SerializeField] public Transform targetPoint = null;

    private int index = 0;
    [SerializeField] private Transform[] route = new Transform[1];

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        this.targetPoint = route[0];
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("bb");
        float distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance <= 5f)
        {
            targetPoint = player.transform;

            if (distance <= 3f)
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
            StartCoroutine(DelayCoroutine());
        }
    }

    bool isactiveCoroutine = false;
    // コルーチン本体
    private IEnumerator DelayCoroutine()
    {
        Debug.Log("呼び出し");

        isactiveCoroutine = true;

        yield return new WaitForSeconds(1f);

        moveSpeed = 3;

        GetComponent<Hontai>().enabled = true;

        enabled = false;

        isactiveCoroutine = false;
    }
    private void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;

        // targetPointへのベクトルを取得し､directionに代入する処理を書く。

        direction = (targetPoint.position - this.transform.position).normalized;

        this.myRigidbody2D.velocity = direction * this.moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        this.moveSpeed = 0;
    }
}
