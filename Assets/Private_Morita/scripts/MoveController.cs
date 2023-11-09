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
    private Animator anim = null;
    //direction = 0 -> 上
    //direction = 1 -> 右
    //direction = 2 -> 下
    //direction = 3 -> 左
    public int direction = 0;
    //[SerializeField] private Sprite[] standSprite = new Sprite[4];
    //private SpriteRenderer mySpriteRenderer = null;
    void Start()
    {
        // オブジェクトに設定しているRigidbody2Dの参照を取得する
        this.rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       // mySpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        /*int inputX = 0;
        int inputY = 0;
        if (Input.GetAxis(KeyCode.A)) { inputX = -1; }
        if (Input.GetAxis(KeyCode.D)) { inputX = 1; }
        if (Input.Get(KeyCode.W)) { inputY = 1; }
        if (Input.GetKeyDown(KeyCode.S)) { inputY = -1; }*/

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (input == Vector3.zero)
        {
            anim.speed = 0;
        }
        else
        {
            anim.speed = 1;
            anim.SetFloat("x", input.x);
            anim.SetFloat("y", input.y);
        }

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
            anim.SetBool("Uwalk", true);
            anim.SetBool("Dwalk", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputAxis.y = -1;
            direction = 2;
            anim.SetBool("Dwalk", true);
            anim.SetBool("Uwalk", false);
           
        }
        else
        {
            inputAxis.y = 0;
            anim.SetBool("Dwalk", false);
            anim.SetBool("Uwalk", false);
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputAxis.x = 1;
            direction = 1;
            anim.SetBool("Rwalk", true);
            anim.SetBool("Lwalk", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputAxis.x = -1;
            direction = 3;
            anim.SetBool("Rwalk", false);
            anim.SetBool("Lwalk", true);

        }
        else
        {
            inputAxis.x = 0;
            anim.SetBool("Rwalk", false);
            anim.SetBool("Lwalk", false);
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
                anim.SetBool("Uattack", true);
            }
            else if (direction == 1)
            {
                vec2 = new Vector2(1, 0);
                anim.SetBool("Rshot", true);
            }
            else if (direction == 2)
            {
                vec2 = new Vector2(0, -1);
                anim.SetBool("Dshot", true);
            }
            else if (direction == 3)
            {
                vec2 = new Vector2(-1, 0);
                anim.SetBool("Lshot", true);
            }
            g.GetComponent<Rigidbody2D>().velocity = vec2 * 3;

            stop = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            stop = false;
            anim.SetBool("Uattack", false);
            anim.SetBool("Rshot", false);
            anim.SetBool("Dshot", false);
            anim.SetBool("Lshot", false);
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
                anim.SetBool("Uattack", true);

            }
            else if (direction == 1)
            {
                vec2 = new Vector2(1, 0);
                anim.SetBool("Rattack", true);
            }
            else if (direction == 2)
            {
                vec2 = new Vector2(0, -1);
                anim.SetBool("Dattack", true);

            }
            else if (direction == 3)
            {
                vec2 = new Vector2(-1, 0);
                transform.localScale = new Vector2(-1, 1);
                anim.SetBool("Lattack", true);
            }
            g.GetComponent<Rigidbody2D>().velocity = vec2 * 3;

            stop = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            stop = false;
            anim.SetBool("Rattack", false);
            anim.SetBool("Dattack", false);
            anim.SetBool("Lattack", false);
            anim.SetBool("Uattack", false);
            transform.localScale = new Vector2(1, 1);

        }
        //mySpriteRenderer.sprite.texture = standSprite[direction];
        //Debug.Log(direction);
       
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
