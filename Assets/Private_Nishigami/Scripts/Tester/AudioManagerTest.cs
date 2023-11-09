using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance_AudioManager.PlaySE(1, 0);
        AudioManager.instance_AudioManager.PlayBGM(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
