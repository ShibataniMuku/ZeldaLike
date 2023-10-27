using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(string.Format("ステージ {0} をクリアした？ => {1}", 1, DataManager.dataManager.getDidClearStage(1)));
        DataManager.dataManager.setDidClearStage(1, true);
        Debug.Log(string.Format("ステージ {0} をクリアした？ => {1}", 1, DataManager.dataManager.getDidClearStage(1)));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
