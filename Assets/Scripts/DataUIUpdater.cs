using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DataUIUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _moneyEarningText;
    [SerializeField] private TextMeshProUGUI _happinessRateText;
    DataSave dataSave;
    char moneySecondChar;
    char moneyThirdChar;

    char earningSecondChar;
    char earningThirdChar;


    private void Awake()
    {
        dataSave = FindObjectOfType<DataSave>();
    }
    public void UpdateData()
    {
        _moneyText.text = DisplayCurrency(dataSave.Money);
        _moneyEarningText.text = DisplayEarningCurrency(dataSave.MoneyEarning);
        _happinessRateText.text = dataSave.HappinessRate.ToString();
    }
    private void Update()
    {
        UpdateData();
    }

    public string DisplayCurrency(BigInteger money)
    {
        int moneyLenght = money.ToString().Length;
        char firstChar = money.ToString()[0];
        if(moneyLenght > 1)
        {
            moneySecondChar = money.ToString()[1];
        }
        if(moneyLenght > 2)
        {
            moneyThirdChar = money.ToString()[2];
        }

        switch (moneyLenght)
        {
            // 0 - 999
            case 0:
            case 1:
            case 2:
            case 3:
                return money.ToString();

            // 1K - 9K
            case 4:
                return $"{firstChar}K";
            // 10K - 99K
            case 5:
                return $"{firstChar}{moneySecondChar}K";
            // 100K - 999K
            case 6:
                return $"{firstChar}{moneySecondChar}{moneyThirdChar}K";
            // 1M - 9.99M
            case 7:
                return $"{firstChar}.{moneySecondChar}{moneyThirdChar}M";
            // 10M - 99.9M
            case 8:
                return $"{firstChar}{moneySecondChar}.{moneyThirdChar}M";
            // 100M - 999M
            case 9:
                return $"{firstChar}{moneySecondChar}{moneyThirdChar}M";
            // 1B - 9.99B
            case 10:
                return $"{firstChar}.{moneySecondChar}{moneyThirdChar}B";
            // 10B - 99.9B
            case 11:
                return $"{firstChar}{moneySecondChar}.{moneyThirdChar}B";
            // 100B - 999B
            case 12:
                return $"{firstChar}{moneySecondChar}{moneyThirdChar}B";
            // 1T - 9.99T
            case 13:
                return $"{firstChar}.{moneySecondChar}{moneyThirdChar}T";
            // 10T - 99.9T
            case 14:
                return $"{firstChar}{moneySecondChar}.{moneyThirdChar}T";
            // 100T - 999T
            case 15:
                return $"{firstChar}{moneySecondChar}{moneyThirdChar}T";
            // 1Qa - 9.99Qa
            case 16:
                return $"{firstChar}.{moneySecondChar}{moneyThirdChar}Qa";
            // 10Qa - 99.9Qa
            case 17:
                return $"{firstChar}{moneySecondChar}.{moneyThirdChar}Qa";
            // 100Qa - 999Qa
            case 18:
                return $"{firstChar}{moneySecondChar}{moneyThirdChar}Qa";
            // 1Qi - 9.99Qi
            case 19:
                return $"{firstChar}.{moneySecondChar}{moneyThirdChar}Qi";
            // 10Qi - 99.9Qi
            case 20:
                return $"{firstChar}{moneySecondChar}.{moneyThirdChar}Qi";
            // 100Qi - 999Qi
            case 21:
                return $"{firstChar}{moneySecondChar}{moneyThirdChar}Qi";
        }
        return string.Empty;
    }
    public string DisplayEarningCurrency(BigInteger moneyEarning)
    {
        int moneyLenght = moneyEarning.ToString().Length;
        char firstChar = moneyEarning.ToString()[0];
        if (moneyLenght > 1)
        {
            earningSecondChar = moneyEarning.ToString()[1];
        }
        if (moneyLenght > 2)
        {
            earningThirdChar = moneyEarning.ToString()[2];
        }

        switch (moneyLenght)
        {
            // 0 - 999
            case 0:
            case 1:
            case 2:
            case 3:
                return moneyEarning.ToString();

            // 1K - 9K
            case 4:
                return $"{firstChar}K";
            // 10K - 99K
            case 5:
                return $"{firstChar}{earningSecondChar}K";
            // 100K - 999K
            case 6:
                return $"{firstChar}{earningSecondChar}{earningThirdChar}K";
            // 1M - 9.99M
            case 7:
                return $"{firstChar}.{earningSecondChar}{earningThirdChar}M";
            // 10M - 99.9M
            case 8:
                return $"{firstChar}{earningSecondChar}.{earningThirdChar}M";
            // 100M - 999M
            case 9:
                return $"{firstChar}{earningSecondChar}{earningThirdChar}M";
            // 1B - 9.99B
            case 10:
                return $"{firstChar}.{earningSecondChar}{earningThirdChar}B";
            // 10B - 99.9B
            case 11:
                return $"{firstChar}{earningSecondChar}.{earningThirdChar}B";
            // 100B - 999B
            case 12:
                return $"{firstChar}{earningSecondChar}{earningThirdChar}B";
            // 1T - 9.99T
            case 13:
                return $"{firstChar}.{earningSecondChar}{earningThirdChar}T";
            // 10T - 99.9T
            case 14:
                return $"{firstChar}{earningSecondChar}.{earningThirdChar}T";
            // 100T - 999T
            case 15:
                return $"{firstChar}{earningSecondChar}{earningThirdChar}T";
            // 1Qa - 9.99Qa
            case 16:
                return $"{firstChar}.{earningSecondChar}{earningThirdChar}Qa";
            // 10Qa - 99.9Qa
            case 17:
                return $"{firstChar}{earningSecondChar}.{earningThirdChar}Qa";
            // 100Qa - 999Qa
            case 18:
                return $"{firstChar}{earningSecondChar}{earningThirdChar}Qa";
            // 1Qi - 9.99Qi
            case 19:
                return $"{firstChar}.{earningSecondChar}{earningThirdChar}Qi";
            // 10Qi - 99.9Qi
            case 20:
                return $"{firstChar}{earningSecondChar}.{earningThirdChar}Qi";
            // 100Qi - 999Qi
            case 21:
                return $"{firstChar}{earningSecondChar}{earningThirdChar}Qi";
        }
        return string.Empty;
    }
}