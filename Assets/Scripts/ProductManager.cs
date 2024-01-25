using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ProductManager : MonoBehaviour
{
    DataSave dataSave;
    public ProductsSO Product;

    private void Start()
    {
        dataSave = FindObjectOfType<DataSave>();
        if(PlayerPrefs.GetString(Product.ProductName) != null)
        {
            if(PlayerPrefs.GetString(PlayerPrefs.GetString(Product.ProductName)) == "true")
            {
                Product.IsProductBought = true;
            }
            else
            {
                Product.IsProductBought= false;
            }
        }
        transform.GetComponent<Image>().sprite = Product.ProductImage;
        transform.GetComponentInChildren<TextMeshProUGUI>().text = Product.ProductName + "\n" + Product.ProductPrice;
    }
    public void BuyProduct()
    {
        if(!Product.IsProductBought && (dataSave.Money >= Product.ProductPrice))
        {
            dataSave.Money -= Product.ProductPrice;
            dataSave.HappinessRate -= Product.EvilnessEffectPoint;
            Product.IsProductBought = true;
            PlayerPrefs.SetString(Product.ProductName, Product.IsProductBought.ToString());
            print("al�nd�");
        }
        else if(!Product.IsProductBought && (dataSave.Money < Product.ProductPrice))
        {
            print("Para yetersiz");
        }
    }
}
