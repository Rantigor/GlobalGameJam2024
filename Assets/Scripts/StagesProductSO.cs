using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StagesSO", fileName = "Stage")]
public class StagesProductsSO : ScriptableObject
{
    public string StageName;
    public int StageLevel;
    public int StageCapacity;
    public float ShowTime;
    public ulong StagePrice;
    public ulong StageEaringIncrease;
    public bool IsStageBought;
    public Sprite StageImage;
}

