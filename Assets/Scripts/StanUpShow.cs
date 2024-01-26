using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StanUpShow : MonoBehaviour
{
    DataSave dataSave;

    [SerializeField] private Slider timerSlider;

    bool isShowContinue = false;
    float _currentShowTime;

    [SerializeField] private GameObject _showEndUI;

    ulong earnedMoney;
    private void Start()
    {
        dataSave = FindObjectOfType<DataSave>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            StageShow();
        }
    }
    public void StageShow()
    {
        if(isShowContinue)
        {
            return;
        }
        else
        {
            isShowContinue = true;
            StartCoroutine(StartTimer());
        }
    }
    IEnumerator StartTimer()
    {
        _currentShowTime = dataSave.ShowTime;
        timerSlider.maxValue = _currentShowTime;
        print("Show Start");
        while (isShowContinue)
        {
            timerSlider.value = _currentShowTime;
            _currentShowTime -= Time.deltaTime;
            yield return new WaitForSecondsRealtime(0.0001f);
            if(_currentShowTime < 0)
            {
                isShowContinue = false;
            }
        }
        print("Show End");
        EndOfStageShow();
    }
    public void EndOfStageShow()
    {
        earnedMoney = (ulong)(dataSave.CurrentStage.ShowTicketPrice * (int)(dataSave.CurrentStage.StageCapacity * (100.01f - dataSave.HappinessRate)/10000));
        dataSave.Money += earnedMoney;
        dataSave.HappinessRate += dataSave.CurrentStage.StageCapacity/10000;
        dataSave.SaveAllData();
        OpenEndUI();
    }

    public void OpenEndUI()
    {
        _showEndUI.SetActive(true);
        GameObject.Find("EarnedMoney").GetComponent<TextMeshProUGUI>().text = earnedMoney.ToString();
        StartCoroutine(CloseEndUI());
    }
    IEnumerator CloseEndUI()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        //close anim
        yield return new WaitForSecondsRealtime(1f);
        _showEndUI.SetActive(false);
    }
}
