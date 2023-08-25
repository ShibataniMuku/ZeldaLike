using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2Controller : MonoBehaviour
{
    public GameObject punch2Prefab;
    [SerializeField]
    float SPEED = 1.0f;
    private Rigidbody2D rigidBody;
    private Vector2 inputAxis;

    //direction = 0 -> ��
    //direction = 1 -> �E
    //direction = 2 -> ��
    //direction = 3 -> ��
    public int direction = 0;
    // Start is called before the first frame update
    void Start()
    {
        // �I�u�W�F�N�g�ɐݒ肵�Ă���Rigidbody2D�̎Q�Ƃ��擾����
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject g = Instantiate(punch2Prefab, transform.position, Quaternion.identity);

            Vector2 vec2 = Vector2.zero;

            //�����ɁA�����idirection�j�ɂ���āAvec2�ɒl�������鏈���������B

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
        }
    }
}
