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

    //�I�[�f�B�IID���d�����Ă��Ȃ������m�F����
    private void CheckOverlap(List<Datum> data, string variable_name)
    {
        List<int> vs = new List<int>();
        for (int i = 0; i < data.Count; i++)
        {
            if (vs.Contains(data[i].id))
            {
                Debug.LogError(string.Format("{0} ��ID {1} ���d�����Ă��܂��B", variable_name, data[i].id));
            }
            else
            {
                vs.Add(data[i].id);
            }
        }
    }

    //�I�[�f�B�IID��index�ɕϊ�����
    public int ConvertIdIntoIndex(List<Datum> data, int id)
    {
        for (int index = 0; index < data.Count; index++)
        {
            if (id == data[index].id)
            {
                return index;
            }
        }

        Debug.LogError(string.Format("�w�肳�ꂽid {0} �̃f�[�^�͑��݂��܂���B", id));

        return -1;
    }

    public void PlaySE(int audioData_ID, int id)
    {

        Debug.Log("���BSE");

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

    // BGM���Đ�����
    public void PlayBGM(int audioData_ID, int id)
    {
        Debug.Log("���BBGM");

        int index = this.ConvertIdIntoIndex(this.audioData[audioData_ID].BGM_Data, id);
        this.BGMSource.clip = this.audioData[audioData_ID].BGM_Data[index].clip;
        this.BGMSource.volume = this.audioData[audioData_ID].BGM_Data[index].volume;
        this.BGMSource.Play();
    }

    // BGM�̍Đ��𒆒f����
    public void StopBGM()
    {
        this.BGMSource.Stop();
    }

    // BGM���|�[�Y����
    public void PauseBGM()
    {
        this.BGMSource.Pause();
    }

    // BGM�̃|�[�Y����������
    public void UnPauseBGM()
    {
        this.BGMSource.UnPause();
    }
}
