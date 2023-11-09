using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    //[SerializeField] GameObject pivot = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("PÉLÅ[Ç™âüÇ≥ÇÍÇ‹ÇµÇΩÅB");
            SettingUIManager.instance_SettingUIManager.SwitchPivotVisible();
        }
    }
}
