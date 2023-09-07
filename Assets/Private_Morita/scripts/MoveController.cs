using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GameObject PunchPrefab;
    public GameObject punch2Prefab;
    [SerializeField]
    float SPEED = 1.0f;
    [SerializeField] private bool dash = false;
    private bool stop = false;
    private Rigidbody2D rigidBody;
    private Vector2 inputAxis;

    //direction = 0 -> 上
    //direction = 1 -> 右
    //direction = 2 -> 下
    //direction = 3 -> 左
    public int direction = 0;

    void Start()
    {
        // オブジェクトに設定しているRigidbody2Dの参照を取得する
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.RightShift))
        {
            dash = true;

        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            dash = false;
        }*/
        dash = Input.GetKey(KeyCode.RightShift);

        // x,ｙの入力値を得る
        // それぞれ+や-の値と入力の関連付けはInput Managerで設定されている

        //inputAxis.x = Input.GetAxis("Horizontal");
        //inputAxis.y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            inputAxis.y = 1;
            direction = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputAxis.y = -1;
            direction = 2;
        }
        else
        {
            inputAxis.y = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputAxis.x = 1;
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputAxis.x = -1;
            direction = 3;
        }
        else
        {
            inputAxis.x = 0;
        }
      //  Debug.Log("inoutAxis => " + this.inputAxis);
       // inputAxis.x = Input.
       // inputAxis.y = Input.Get


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           GameObject g = Instantiate(PunchPrefab, transform.position, Quaternion.identity);

            Vector2 vec2 = Vector2.zero;

            //ここに、方向（direction）によって、vec2に値を代入する処理を書く。

            if (direction == 0)
            {
                vec2 = new Vector2(0, 1);
            }
            else if (direction == 1)
            {
                vec2 = new Vector2(1, 0);
            }
            else if (direction == 2)
            {
                vec2 = new Vector2(0, -1);
            }
            else if (direction == 3)
            {
                vec2 = new Vector2(-1, 0);
            }
            g.GetComponent<Rigidbody2D>().velocity = vec2 * 3;

            stop = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            stop = false;
        }
        //stop = Input.GetKey(KeyCode.RightArrow);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject g = Instantiate(punch2Prefab, transform.position, Quaternion.identity);

            Vector2 vec2 = Vector2.zero;

            //ここに、方向（direction）によって、vec2に値を代入する処理を書く。

            if (direction == 0)
            {
                vec2 = new Vector2(0, 1);
            }
            else if (direction == 1)
            {
                vec2 = new Vector2(1, 0);
            }
            else if (direction == 2)
            {
                vec2 = new Vector2(0, -1);
            }
            else if (direction == 3)
            {
                vec2 = new Vector2(-1, 0);
            }
            g.GetComponent<Rigidbody2D>().velocity = vec2 * 3;

            stop = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            stop = false;
        }
        //if (Input.GetKey(KeyCode.RightShift))
        //{
        //ここに速さを二倍にするのを入れたい

        // }

    }

    private void FixedUpdate()
    {
        // 速度を代入する
        
        if (dash == false)
        {
            rigidBody.velocity = inputAxis.normalized * SPEED;
        }
        else
        {
            rigidBody.velocity = inputAxis.normalized * SPEED * 2;
        }
        if (stop == true)
        {
            rigidBody.velocity = inputAxis.normalized * SPEED * 0;
        }
        
    }
}
