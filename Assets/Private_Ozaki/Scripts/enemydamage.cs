using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage: MonoBehaviour
{

    //[SerializeField]���������Ƃɂ��public�łȂ��Ă�Inspector����l��ҏW�ł��܂�
    [SerializeField]
    private float hp = 5;  //�̗�

    //�ђʂ���ꍇ��Trigger�n(�ǂ��炩��Collider��is trigger���`�F�b�N) �Փ˂��������̂�Collision�n(Collider��Rigidbody���K�v)
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //�̗͂�0�ȉ��ɂȂ�����{}���̏������s����
        if (hp <= 0)
        {
            Destroy(gameObject);  //�Q�[���I�u�W�F�N�g���j�󂳂��
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("�_���[�W");

    }
}
