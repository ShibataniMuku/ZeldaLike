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
        //�X���C�_�[�𓮂��������̏�����o�^
        bgmSlider.onValueChanged.AddListener(SetAudioMixerBGM);
        seSlider.onValueChanged.AddListener(SetAudioMixerSE);

        SwitchPivotVisible();
    }

    //BGM
    public void SetAudioMixerBGM(float value)
    {
        //5�i�K�␳
        value /= 5;
        //-80~0�ɕϊ�
        var volume = Mathf.Clamp(Mathf.Log10(value) * 20f, -80f, 0f);
        //audioMixer�ɑ��
        audioMixer.SetFloat("BGM", volume);
        Debug.Log($"BGM:{volume}");
    }

    //SE
    public void SetAudioMixerSE(float value)
    {
        //5�i�K�␳
        value /= 5;
        //-80~0�ɕϊ�
        var volume = Mathf.Clamp(Mathf.Log10(value) * 20f, -80f, 0f);
        //audioMixer�ɑ��
        audioMixer.SetFloat("SE", volume);
        Debug.Log($"SE:{volume}");

    }

    public void SwitchPivotVisible()
    {
        this.pivot.SetActive(!this.pivot.activeSelf);
    }

    //���������R�ɕς��ĂˁI
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchPivotVisible();
        }
    }
    //���������R�ɕς��ĂˁI
}
