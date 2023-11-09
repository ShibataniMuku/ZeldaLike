using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager dataManager;

    private void Awake()
    {
        if (dataManager == null)
        {
            dataManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private const int stageNumber = 3;

    public List<bool> didClearStage = new List<bool>(new bool[stageNumber]);

    // あるステージをクリアしたかを取得する
    // 引数：int stageNumber：ステージ数を表す。（例：ステージ１がクリアしているかどうか知りたい ⇒ 引数に１を渡す。）
    // 戻り値：bool型：ステージをクリアしたかどうか
    public bool getDidClearStage(int stageNumber)
    {
        if (stageNumber == -999)
        {
            return true;
        }
        else if (stageNumber < 1 || stageNumber > this.didClearStage.Count)
        {
            Debug.Log(string.Format("【 DataManager：getDidClearStage() 】ステージ {0} は存在しません。", stageNumber));
        }

        return this.didClearStage[stageNumber - 1];
    }

    // あるステージをクリアしたかを設定する
    // 引数：int stageNumber：ステージ数を表す。（例：ステージ１がクリアしているかどうか知りたい ⇒ 引数に１を渡す。）
    // 引数：bool b：クリアしたかどうか
    public void setDidClearStage(int stageNumber, bool b)
    {
        if (stageNumber < 1 || stageNumber > this.didClearStage.Count)
        {
            Debug.Log(string.Format("【 DataManager：setDidClearStage() 】ステージ {0} は存在しません。", stageNumber));
        }

        this.didClearStage[stageNumber - 1] = b;
    }
}
