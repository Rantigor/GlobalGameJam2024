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
    public float ShowTime = 10;
    [Range(0, 100)]
    public int HappinessRate;
    public int StageLevel = 1;
    [SerializeField]List<StagesProductsSO> Stages;
    public Image StageImage;
    private void Start()
    {
        LoadAllData();
        SetStageImage();
    }

    public void SetStageImage()
    {
        foreach (StagesProductsSO stoge in Stages)
        {
            if (stoge.StogeLevel == StageLevel && stoge.IsStageBought)
            {
                StageImage.sprite = stoge.StageImage;
                print("dfga");
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
        SaveAllData();
    }
}
