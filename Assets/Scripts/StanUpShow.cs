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
    private DataSave dataSave;

    [SerializeField] private Slider timerSlider;

    public bool isShowContinue = false;
    public float _currentShowTime;
    int _currentShowNumber = 0;

    [SerializeField] private GameObject _showEndUI;

    public ulong earnedMoney;

    private AudienceEvent _audienceEvent;

    private void Start()
    {
        dataSave = FindObjectOfType<DataSave>();
        _currentShowTime = PlayerPrefs.GetInt(nameof(_currentShowNumber));
        _audienceEvent = FindObjectOfType<AudienceEvent>();
    }
    public void StageShow()
    {
        if(_showEndUI.activeSelf || isShowContinue)
        {
            return;
        }
        else
        {
            isShowContinue = true;
            timerSlider.gameObject.SetActive(true);
            StartCoroutine(StartTimer());
            StartCoroutine(_audienceEvent.RandomTimeCreateEvent());
        }
    }

    IEnumerator StartTimer()
    {
        _currentShowTime = dataSave.ShowTime;
        timerSlider.maxValue = _currentShowTime;
        while (isShowContinue)
        {
            timerSlider.value = _currentShowTime;
            _currentShowTime -= Time.deltaTime;
            yield return new WaitForSecondsRealtime(0.0001f);
            if(_currentShowTime < 0)
            {
                isShowContinue = false;
                timerSlider.gameObject.SetActive(false);
            }
        }
        EndOfStageShow();
    }
    private void EndOfStageShow()
    {
        earnedMoney = (ulong)(dataSave.CurrentStage.ShowTicketPrice * (int)(dataSave.CurrentStage.StageCapacity * (100.01f - dataSave.HappinessRate)/10000));
        dataSave.Money += earnedMoney;
        dataSave.HappinessRate += dataSave.CurrentStage.StageCapacity/10000;
        _currentShowNumber++;
        dataSave.SaveAllData();
        OpenEndUI();
        PlayerPrefs.SetInt(nameof(_currentShowNumber), _currentShowNumber);
    }

    private void OpenEndUI()
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
        if(_currentShowNumber >= dataSave.ShowNumber)
        {
            //evine yolla
            _currentShowNumber = 0;
        }
    }
}
