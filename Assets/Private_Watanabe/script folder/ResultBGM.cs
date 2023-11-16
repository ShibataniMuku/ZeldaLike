using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance_AudioManager.PlayBGM(4, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
