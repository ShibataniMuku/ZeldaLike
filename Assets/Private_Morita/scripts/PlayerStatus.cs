using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

   [SerializeField] private int HP = 100;
    public int GetHP()
    {
        return this.HP;
    }
    // Start is called before the first frame update
    /*void Start()
    {
        Debug.Log(string.Format("HP => {0}", HP));
        decreaseHP(10);

        Debug.Log(string.Format("HP => {0}", HP));
        decreaseHP(-10);
        Debug.Log(string.Format("HP => {0}", HP));
    }*/
    public void decreaseHP(int amount)
    {
        Debug.Log("decreaseHP‚ª‚æ‚Î‚ê‚½");
        //HP = HP - amount;
        HP -= Mathf.Abs(amount);
        
    }
    // Update is called once per frame
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
