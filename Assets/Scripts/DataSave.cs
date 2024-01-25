using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using System.Numerics;
using System;
using UnityEngine.UI;

public class DataSave : MonoBehaviour
{
    public BigInteger Money = 0;
    public BigInteger MoneyEarning = 110;
    public float ShowTime;
    [Range(0, 100)]
    public int HappinessRate;
    public int StageLevel = 0;
    [SerializeField]List<StagesProductsSO> Stages;
    public StagesProductsSO CurrentStage;
    public Image StageImage;
    private void Start()
    {
        SaveAllData();
        LoadAllData();
        SetStageImage();
    }

    public void SetStageImage()
    {
        foreach (StagesProductsSO stage in Stages)
        {
            if (stage.StageLevel == StageLevel && stage.IsStageBought)
            {
                StageImage.sprite = stage.StageImage;
                ShowTime = stage.ShowTime;
                CurrentStage = stage;
            }
        }
    }

    private void Update()
    {
        if(HappinessRate <= 0)
        {
            HappinessRate = 0;
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void SaveAllData()
    {
        PlayerPrefs.SetString(nameof(Money), Money.ToString());
        PlayerPrefs.SetString(nameof(MoneyEarning), MoneyEarning.ToString());
        PlayerPrefs.SetFloat(nameof(ShowTime), ShowTime);
        PlayerPrefs.SetInt(nameof(StageLevel), StageLevel);
        PlayerPrefs.SetInt(nameof(HappinessRate), HappinessRate);
    }
    public void LoadAllData()
    {
        Money = BigInteger.Parse(PlayerPrefs.GetString(nameof(Money)));
        MoneyEarning = BigInteger.Parse(PlayerPrefs.GetString(nameof(MoneyEarning)));
        ShowTime = PlayerPrefs.GetFloat(nameof(ShowTime));
        StageLevel = PlayerPrefs.GetInt(nameof(StageLevel));
        HappinessRate = PlayerPrefs.GetInt(nameof(HappinessRate));
    }
    private void OnApplicationQuit()
    {
        //SaveAllData();
    }
}
