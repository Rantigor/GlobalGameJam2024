using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(menuName ="ProductSO", fileName ="Product")]
public class ProductsSO : ScriptableObject
{
    public string ProductName;
    public ulong ProductPrice;
    public bool IsProductBought;
    [Range(0,100)]
    public int EvilnessEffectPoint;
    public Sprite ProductImage;
}
