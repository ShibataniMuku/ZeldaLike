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

    private AudioSource sound1;

    private AudioSource sound2;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        sound1 = audioSources[0];
        
        sound2 = audioSources[1];
    }

    //private void OnCollisionEnter2D(Collision2D other)
    public void DecreaseHP(int damage)
    {
        Debug.Log("É_ÉÅÅ[ÉW");

        HP -= damage;

        sound1.PlayOneShot(sound1.clip);
    }
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);

            sound2.PlayOneShot(sound2.clip);
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
