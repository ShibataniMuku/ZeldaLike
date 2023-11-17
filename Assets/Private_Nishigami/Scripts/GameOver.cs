using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance_AudioManager.PlayBGM(4, 4);
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
