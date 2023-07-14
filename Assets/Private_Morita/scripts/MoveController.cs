using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GameObject PunchPrefab;
    [SerializeField]
    float SPEED = 1.0f;
    private Rigidbody2D rigidBody;
    private Vector2 inputAxis;

    void Start()
    {
        // オブジェクトに設定しているRigidbody2Dの参照を取得する
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // x,ｙの入力値を得る
        // それぞれ+や-の値と入力の関連付けはInput Managerで設定されている
        inputAxis.x = Input.GetAxis("Horizontal");
        inputAxis.y = Input.GetAxis("Vertical");
        //inputAxis.x = Input.
        //inputAxis.y = Input.Get
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(PunchPrefab, transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        // 速度を代入する
        rigidBody.velocity = inputAxis.normalized * SPEED;
    }
}
