using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("��������(s)")]
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
    /// ���Ԃ����Z�E���Z����
    /// </summary>
    /// <param name="time">�ǉ����鎞��</param>
    public void AddTime(float time)
    {
        currentTimeLimit += time;
        Debug.Log($"�c�莞�� {time} �b�ǉ�");
    }

    /// <summary>
    /// �c�莞�Ԃ̊�����Ԃ�
    /// </summary>
    /// <returns></returns>
    public float GetTimeLimitRate()
    {
        float rate = currentTimeLimit / TIME_LIMIT;
        if (rate > 1) rate = 1;
        return rate;
    }
}
