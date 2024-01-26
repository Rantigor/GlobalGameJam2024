using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(menuName ="ProductSO", fileName ="Product")]
public class ProductsSO : ScriptableObject
{
    public string ProductName;
    public ulong ProductPrice;
    public int ProductLevel;
    [Range(0,100)]
    public float EvilnessEffectPoint;
    public Sprite ProductImage;
}
