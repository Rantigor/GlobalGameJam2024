using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class StanUpShow : MonoBehaviour
{
    DataSave dataSave;

    [SerializeField] private Slider timerSlider;

    bool isShowContinue = true;
    float _currentShowTime;
    private void Start()
    {
        dataSave = FindObjectOfType<DataSave>();
        StageShow();
    }
    public void StageShow()
    {
        StartCoroutine(StartTimer());
        
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
        dataSave.Money += (int)(dataSave.MoneyEarning + (dataSave.MoneyEarning * (int)(100.01f - dataSave.HappinessRate)/100));
        dataSave.SaveAllData();
    }
}
