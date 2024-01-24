using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using System.Numerics;
using System;

public class DataSave : MonoBehaviour
{
    public BigInteger Money = 0;
    public BigInteger MoneyEarning = 110;
    public float ShowTime = 10;
    [Range(0, 100)]
    public int HappinessRate;
    private void Start()
    {
        LoadAllData();
    }
    private void Update()
    {
        if(HappinessRate <= 0)
        {
            HappinessRate = 0;
        }
    }

    public void SaveAllData()
    {
        PlayerPrefs.SetString(nameof(Money), Money.ToString());
        PlayerPrefs.SetString(nameof(MoneyEarning), MoneyEarning.ToString());
        PlayerPrefs.SetFloat(nameof(ShowTime), ShowTime);
        PlayerPrefs.SetInt(nameof(HappinessRate), HappinessRate);
    }
    public void LoadAllData()
    {
        Money = BigInteger.Parse(PlayerPrefs.GetString(nameof(Money)));
        MoneyEarning = BigInteger.Parse(PlayerPrefs.GetString(nameof(MoneyEarning)));
        ShowTime = PlayerPrefs.GetFloat(nameof(ShowTime));
        HappinessRate = PlayerPrefs.GetInt(nameof(HappinessRate));
    }
    private void OnApplicationQuit()
    {
        SaveAllData();
    }
}
