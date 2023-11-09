using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingUIManager : MonoBehaviour
{
    public static SettingUIManager instance_SettingUIManager;
    private void Awake()
    {
        if (instance_SettingUIManager == null)
        {
            instance_SettingUIManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject pivot = null;

    // Start is called before the first frame update
    void Start()
    {
        this.pivot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchPivotVisible();
        }*/
    }

    public void viewPivot()
    {
        Time.timeScale = 0;
        //Cursor.visible = true;
        this.pivot.SetActive(true);
    }

    public void hidePivot()
    {
        Time.timeScale = 1;
        //Cursor.visible = false;
        this.pivot.SetActive(false);
    }

    public void SwitchPivotVisible()
    {
        if (this.pivot.activeSelf)
        {
            hidePivot();
        }
        else
        {
            viewPivot();
        }
    }

    public void button_Resume()
    {
        hidePivot();
    }

    public void button_StageSelect(string stage_name)
    {
        hidePivot();
        SceneManager.LoadScene(stage_name);
    }

    public void button_Setting()
    {
        AudioVolume.instance_AudioVolume.SwitchPivotVisible();
    }
}
