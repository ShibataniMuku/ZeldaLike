using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("制限時間(s)")]
    public const float TIME_LIMIT = 300;
    [HideInInspector]
    private float currentTimeLimit;
    [HideInInspector]
    public bool isActiveTimer { get; set; } = false;

    [SerializeField]
    private PhaseManager phaseManager;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeLimit = TIME_LIMIT;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveTimer)
        {
            if (currentTimeLimit > 0)
            {
                currentTimeLimit -= Time.deltaTime;
            }
            else
            {
                isActiveTimer = false;
                phaseManager.GameOver();
            }
        }
    }

    /// <summary>
    /// 時間を加算・減算する
    /// </summary>
    /// <param name="time">追加する時間</param>
    public void AddTime(float time)
    {
        currentTimeLimit += time;
        Debug.Log($"残り時間 {time} 秒追加");
    }

    /// <summary>
    /// 残り時間の割合を返す
    /// </summary>
    /// <returns></returns>
    public float GetTimeLimitRate()
    {
        float rate = currentTimeLimit / TIME_LIMIT;
        if (rate > 1) rate = 1;
        return rate;
    }
}
