using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemyattack : MonoBehaviour
{

    //�v���C���[�I�u�W�F�N�g
    public GameObject player;
    //�e�̃v���n�u�I�u�W�F�N�g
    public GameObject tama;

    //��b���Ƃɒe�𔭎˂��邽�߂̂���
    private float targetTime = 1.0f;
    private float currentTime = 0;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) <= 3.5f)
        { 
            //��b�o���Ƃɒe�𔭎˂���
            currentTime += Time.deltaTime;
            
            if (targetTime < currentTime)
            {
                currentTime = 0;
                //�G�̍��W��ϐ�pos�ɕۑ�
                var pos = this.gameObject.transform.position;
                //�G����v���C���[�Ɍ������x�N�g��������
                //�v���C���[�̈ʒu����G�̈ʒu�i�e�̈ʒu�j������
                Vector3 vec = player.transform.position - pos;
                //�e�̃v���n�u���쐬
                GameObject t = Instantiate(tama, pos + vec.normalized * 1.05f, Quaternion.identity);
                //�e��RigidBody2D�R���|�l���g��velocity�ɐ�����߂��x�N�g�������ė͂�������
                t.GetComponent<Rigidbody2D>().velocity = vec.normalized * 3.3f;
                //Debug.Log(vec);
            }
        }
    }
}
