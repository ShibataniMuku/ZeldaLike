using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    public static AudioVolume instance_AudioVolume;
    private void Awake()
    {
        if (instance_AudioVolume == null)
        {
            instance_AudioVolume = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;

    [SerializeField] private GameObject pivot = null;

    void Start()
    {
        //スライダーを動かした時の処理を登録
        bgmSlider.onValueChanged.AddListener(SetAudioMixerBGM);
        seSlider.onValueChanged.AddListener(SetAudioMixerSE);

        SwitchPivotVisible();
    }

    //BGM
    public void SetAudioMixerBGM(float value)
    {
        //5段階補正
        value /= 5;
        //-80~0に変換
        var volume = Mathf.Clamp(Mathf.Log10(value) * 20f, -80f, 0f);
        //audioMixerに代入
        audioMixer.SetFloat("BGM", volume);
        Debug.Log($"BGM:{volume}");
    }

    //SE
    public void SetAudioMixerSE(float value)
    {
        //5段階補正
        value /= 5;
        //-80~0に変換
        var volume = Mathf.Clamp(Mathf.Log10(value) * 20f, -80f, 0f);
        //audioMixerに代入
        audioMixer.SetFloat("SE", volume);
        Debug.Log($"SE:{volume}");

    }

    public void SwitchPivotVisible()
    {
        this.pivot.SetActive(!this.pivot.activeSelf);
    }

    //ここを自由に変えてね！
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchPivotVisible();
        }
    }
    //ここを自由に変えてね！
}
