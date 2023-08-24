using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hontai : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D myRigidbody2D = null;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        transform.DOMove(player.transform.position, 1f).SetEase(Ease.Linear).SetLoops(1, LoopType.Yoyo);

        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        while (true)
        {
            if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                transform.DOMove(player.transform.position, 1f).SetEase(Ease.Linear).SetLoops(1, LoopType.Yoyo);
            }

            else if (Vector2.Distance(this.transform.position, player.transform.position) > 3f)
            {
                GetComponent<Rush>().enabled = true;

                enabled = false;
            }

            yield return new WaitForSeconds(1f);
        }

    }
   
}
