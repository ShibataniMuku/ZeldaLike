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
        // �I�u�W�F�N�g�ɐݒ肵�Ă���Rigidbody2D�̎Q�Ƃ��擾����
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // x,���̓��͒l�𓾂�
        // ���ꂼ��+��-�̒l�Ɠ��͂̊֘A�t����Input Manager�Őݒ肳��Ă���
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
        // ���x��������
        rigidBody.velocity = inputAxis.normalized * SPEED;
    }
}