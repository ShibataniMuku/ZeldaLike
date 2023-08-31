using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(0.8f);

        Destroy(this.gameObject);
    }
}
