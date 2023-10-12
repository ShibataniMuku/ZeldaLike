using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

    public class Walkanimation : MonoBehaviour
{
    private Animator Wanim = null;

    private 
    // Start is called before the first frame update
    void Start()
    {
        Wanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*GetComponent<targetpoint>

        float angle = GetAngle(this.transform.position,targetpoint.position);*/



        Wanim.SetInteger("Walk int", 1);
    }
}