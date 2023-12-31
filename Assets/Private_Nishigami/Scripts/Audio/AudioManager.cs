using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance_AudioManager;
    private void Awake()
    {
        if (instance_AudioManager == null)
        {
            instance_AudioManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private AudioData[] audioData = new AudioData[5];

    [SerializeField] private AudioSource SESource;
    [SerializeField] private AudioSource BGMSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] tmp = this.GetComponents<AudioSource>();
        this.SESource = tmp[0];
        this.BGMSource = tmp[1];

        foreach (AudioData aD in audioData)
        {
            CheckOverlap(aD.SE_Data, "SE_Data");
            CheckOverlap(aD.BGM_Data, "BGM_Data");
        }

        
    }

    //オーディオIDが重複していないかを確認する
    private void CheckOverlap(List<Datum> data, string variable_name)
    {
        List<int> vs = new List<int>();
        for (int i = 0; i < data.Count; i++)
        {
            if (vs.Contains(data[i].id))
            {
                Debug.LogError(string.Format("{0} のID {1} が重複しています。", variable_name, data[i].id));
            }
            else
            {
                vs.Add(data[i].id);
            }
        }
    }

    //オーディオIDをindexに変換する
    public int ConvertIdIntoIndex(List<Datum> data, int id)
    {
        for (int index = 0; index < data.Count; index++)
        {
            if (id == data[index].id)
            {
                return index;
            }
        }

        Debug.LogError(string.Format("指定されたid {0} のデータは存在しません。", id));

        return -1;
    }

    public void PlaySE(int audioData_ID, int id)
    {

        Debug.Log("到達SE");

        int index = this.ConvertIdIntoIndex(this.audioData[audioData_ID].SE_Data, id);
        this.SESource.clip = this.audioData[audioData_ID].SE_Data[index].clip;
        this.SESource.volume = this.audioData[audioData_ID].SE_Data[index].volume;
        this.SESource.Play();
    }

    public void StopSE()
    {
        this.SESource.Stop();
    }

    public void PauseSE()
    {
        this.SESource.Pause();
    }

    public void UnPauseSE()
    {
        this.SESource.UnPause();
    }

    // BGMを再生する
    public void PlayBGM(int audioData_ID, int id)
    {
        Debug.Log("到達BGM");

        int index = this.ConvertIdIntoIndex(this.audioData[audioData_ID].BGM_Data, id);
        this.BGMSource.clip = this.audioData[audioData_ID].BGM_Data[index].clip;
        this.BGMSource.volume = this.audioData[audioData_ID].BGM_Data[index].volume;
        this.BGMSource.Play();
    }

    // BGMの再生を中断する
    public void StopBGM()
    {
        this.BGMSource.Stop();
    }

    // BGMをポーズする
    public void PauseBGM()
    {
        this.BGMSource.Pause();
    }

    // BGMのポーズを解除する
    public void UnPauseBGM()
    {
        this.BGMSource.UnPause();
    }
}
