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
    public BigInteger MoneyEarning = 0;
    public float ShowTime = 0;
    [Range(0, 100)]
    public float HappinessRate = 0;
    public int StageLevel = 0;
    [SerializeField]List<StagesProductsSO> Stages;
    public StagesProductsSO CurrentStage;
    public Image StageImage;
    public int DayNumber = 1;
    public int ShowNumber = 1;
    AudienceEvent audienceEvent;
    private void Start()
    {
        audienceEvent = FindObjectOfType<AudienceEvent>();
        if (PlayerPrefs.GetString(nameof(Money)) == "")
        {
            SaveAllData();
        }
        LoadAllData();
        audienceEvent.LoadEventData();
        SetStageImage();


        MoneyEarning = CurrentStage.StageEaringIncrease;
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
        PlayerPrefs.SetFloat(nameof(HappinessRate), HappinessRate);
        PlayerPrefs.SetInt(nameof(DayNumber), DayNumber);
        PlayerPrefs.SetInt(nameof(ShowNumber), ShowNumber);

        if(CurrentStage != null)
            PlayerPrefs.SetInt(CurrentStage.StageName, CurrentStage.ShowTicketPrice);
    }
    public void LoadAllData()
    {
        Money = BigInteger.Parse(PlayerPrefs.GetString(nameof(Money)));
        MoneyEarning = BigInteger.Parse(PlayerPrefs.GetString(nameof(MoneyEarning)));
        ShowTime = PlayerPrefs.GetFloat(nameof(ShowTime));
        StageLevel = PlayerPrefs.GetInt(nameof(StageLevel));
        HappinessRate = PlayerPrefs.GetFloat(nameof(HappinessRate));
        DayNumber = PlayerPrefs.GetInt(nameof(DayNumber));
        ShowNumber = PlayerPrefs.GetInt(nameof(ShowNumber));

        if (CurrentStage != null)
            CurrentStage.ShowTicketPrice = PlayerPrefs.GetInt(CurrentStage.StageName);
    }
    private void OnApplicationQuit()
    {
        //SaveAllData();
        //audienceEvent.SaveEventData();
    }
}
