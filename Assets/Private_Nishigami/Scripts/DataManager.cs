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

    // ����X�e�[�W���N���A���������擾����
    // �����Fint stageNumber�F�X�e�[�W����\���B�i��F�X�e�[�W�P���N���A���Ă��邩�ǂ����m�肽�� �� �����ɂP��n���B�j
    // �߂�l�Fbool�^�F�X�e�[�W���N���A�������ǂ���
    public bool getDidClearStage(int stageNumber)
    {
        if (stageNumber == -999)
        {
            return true;
        }
        else if (stageNumber < 1 || stageNumber > this.didClearStage.Count)
        {
            Debug.Log(string.Format("�y DataManager�FgetDidClearStage() �z�X�e�[�W {0} �͑��݂��܂���B", stageNumber));
        }

        return this.didClearStage[stageNumber - 1];
    }

    // ����X�e�[�W���N���A��������ݒ肷��
    // �����Fint stageNumber�F�X�e�[�W����\���B�i��F�X�e�[�W�P���N���A���Ă��邩�ǂ����m�肽�� �� �����ɂP��n���B�j
    // �����Fbool b�F�N���A�������ǂ���
    public void setDidClearStage(int stageNumber, bool b)
    {
        if (stageNumber < 1 || stageNumber > this.didClearStage.Count)
        {
            Debug.Log(string.Format("�y DataManager�FsetDidClearStage() �z�X�e�[�W {0} �͑��݂��܂���B", stageNumber));
        }

        this.didClearStage[stageNumber - 1] = b;
    }
}
