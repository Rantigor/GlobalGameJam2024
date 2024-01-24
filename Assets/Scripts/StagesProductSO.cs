using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StagesSO", fileName = "Stage")]
public class StagesProductsSO : ScriptableObject
{
    public string StageName;
    public int StogeLevel;
    public ulong StagePrice;
    public ulong StageEaringIncrease;
    public bool IsStageBought;
    public Sprite StageImage;
}

