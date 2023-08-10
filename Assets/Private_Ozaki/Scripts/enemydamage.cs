using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage: MonoBehaviour
{

    //[SerializeField]を書くことによりpublicでなくてもInspectorから値を編集できます
    [SerializeField]
    private float hp = 5;  //体力

    //貫通する場合はTrigger系(どちらかにColliderのis triggerをチェック) 衝突しあうものはCollision系(ColliderとRigidbodyが必要)
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //体力が0以下になった時{}内の処理が行われる
        if (hp <= 0)
        {
            Destroy(gameObject);  //ゲームオブジェクトが破壊される
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ダメージ");

    }
}
