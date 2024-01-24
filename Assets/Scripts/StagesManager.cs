using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StagesManager : MonoBehaviour
{
    DataSave dataSave;
    public StagesProductsSO Stage;

    private void Start()
    {
        dataSave = FindObjectOfType<DataSave>();
        if (PlayerPrefs.GetString(Stage.StageName) != null)
        {
            if (PlayerPrefs.GetString(PlayerPrefs.GetString(Stage.StageName)) == "true")
            {
                Stage.IsStageBought= true;
            }
            else
            {
                Stage.IsStageBought= false;
            }
        }
        transform.GetComponent<Image>().sprite = Stage.StageImage;
        transform.GetComponentInChildren<TextMeshProUGUI>().text = Stage.StageName + "\n" + Stage.StagePrice;
    }

    public void BuyStage()
    {
        if (!Stage.IsStageBought && (dataSave.Money >= Stage.StagePrice))
        {
            dataSave.Money -= Stage.StagePrice;
            dataSave.MoneyEarning += Stage.StageEaringIncrease;
            Stage.IsStageBought= true;
            PlayerPrefs.SetString(Stage.StageName, Stage.IsStageBought.ToString());
            dataSave.StageLevel = Stage.StogeLevel;
            dataSave.SetStageImage();
            print("alýndý");
        }
    }
}
