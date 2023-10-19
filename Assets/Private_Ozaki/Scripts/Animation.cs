using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

    public class Animation : MonoBehaviour
{
    private Animator Wanim = null;

    // Start is called before the first frame update
    void Start()
    {
        Wanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //‚±‚±‚Étargetpoint‚ð‚¢‚ê‚½‚¢

        /*float angle = GetAngle(this.transform.position,targetpoint.position);

        if (angle >= -135 && angle < -45)
        {
            Wanim.SetInteger("Wanim int", 1);
        }

        if (angle >= 45 && angle < 135)
        {
            Wanim.SetInteger("Walk int", 2);
        }

        if (angle >= 135 && angle < -135)
        {
            Wanim.SetInteger("Walk int", 3);
        }

        if (angle >= -45 && angle < 45)
        {
            Wanim.SetInteger("Walk int", 4);
        }*/
    }

    float GetAngle(Vector2 position, Vector2 targetPoint)
    {
        Vector2 dt = targetPoint - position;

        float rad = Mathf.Atan2(dt.y, dt.x);

        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }
}