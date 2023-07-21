using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Slider masterSlider;
    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider seSlider;
    [SerializeField]
    private AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("Master", 0.8f);
        bgmSlider.value = PlayerPrefs.GetFloat("BGM", 0.8f);
        seSlider.value = PlayerPrefs.GetFloat("SE", 0.8f);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeVolume(string name)
    {
        switch (name)
        {
            case "Master":
                audioMixer.SetFloat("Master", masterSlider.value * 100 - 80); break;
            case "BGM":
                audioMixer.SetFloat("BGM", bgmSlider.value * 100 - 80); break;
            case "SE":
                audioMixer.SetFloat("SE", seSlider.value * 100 - 80); break;
        }
    }

    public void ShowSettingsPanel() // 設定画面を表示するときに、この関数を呼び出す
    {
        gameObject.SetActive(true);
    }

    public void HideSettingsPanel() // 設定画面を非表示にするときに、この関数を呼び出す
    {
        PlayerPrefs.SetFloat("Master", masterSlider.value);
        PlayerPrefs.SetFloat("BGM", bgmSlider.value);
        PlayerPrefs.SetFloat("SE", seSlider.value);
        gameObject.SetActive(false);
    }
}