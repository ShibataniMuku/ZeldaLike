using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemystatus : MonoBehaviour//, IDamegeable
{
    /* public interface IDamegeable
 {
     public void Damage(int value);

     public void Death();
 }*/

    [SerializeField]
    private int HP = 30;

    //private void OnCollisionEnter2D(Collision2D other)
    public void DecreaseHP(int damage)
    {
        Debug.Log("�_���[�W");

        HP -= damage;
    }
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Death()
    {

    }
}
/*public interface IDamegeable
{
    public void Damage(int value);

    public void Death();
}*/