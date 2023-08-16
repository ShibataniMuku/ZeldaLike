using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("§ŒÀŠÔ(s)")]
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
    /// ŠÔ‚ğ‰ÁZEŒ¸Z‚·‚é
    /// </summary>
    /// <param name="time">’Ç‰Á‚·‚éŠÔ</param>
    public void AddTime(float time)
    {
        currentTimeLimit += time;
        Debug.Log($"c‚èŠÔ {time} •b’Ç‰Á");
    }

    /// <summary>
    /// c‚èŠÔ‚ÌŠ„‡‚ğ•Ô‚·
    /// </summary>
    /// <returns></returns>
    public float GetTimeLimitRate()
    {
        float rate = currentTimeLimit / TIME_LIMIT;
        if (rate > 1) rate = 1;
        return rate;
    }
}
