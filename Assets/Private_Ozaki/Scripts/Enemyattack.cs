using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemyattack : MonoBehaviour
{

    //プレイヤーオブジェクト
    public GameObject player;
    //弾のプレハブオブジェクト
    public GameObject tama;

    //一秒ごとに弾を発射するためのもの
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
            //一秒経つごとに弾を発射する
            currentTime += Time.deltaTime;
            
            if (targetTime < currentTime)
            {
                currentTime = 0;
                //敵の座標を変数posに保存
                var pos = this.gameObject.transform.position;
                //敵からプレイヤーに向かうベクトルをつくる
                //プレイヤーの位置から敵の位置（弾の位置）を引く
                Vector3 vec = player.transform.position - pos;
                //弾のプレハブを作成
                GameObject t = Instantiate(tama, pos + vec.normalized * 1.05f, Quaternion.identity);
                //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
                t.GetComponent<Rigidbody2D>().velocity = vec.normalized * 3.3f;
                //Debug.Log(vec);
            }
        }
    }
}
