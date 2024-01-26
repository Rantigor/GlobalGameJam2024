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
    public List<ProductsSO> Products;
    int _currentProduct = 0;

    private void Start()
    {
        dataSave = FindObjectOfType<DataSave>();
        SaveProductData();
        LoadProductData();

        while(Products[_currentProduct].ProductLevel >= 10)
        {
            PlayerPrefs.DeleteKey(Products[_currentProduct].ProductName);
            _currentProduct++;
            SaveProductData();
            LoadProductData();
        }
        transform.GetComponent<Image>().sprite = Products[_currentProduct].ProductImage;
        transform.GetComponentInChildren<TextMeshProUGUI>().text = Products[_currentProduct].ProductName + "\n" + Products[_currentProduct].ProductPrice;
    }
    public void BuyProduct()
    {
        if((dataSave.Money >= Products[_currentProduct].ProductPrice))
        {
            dataSave.Money -= Products[_currentProduct].ProductPrice;
            dataSave.HappinessRate -= Products[_currentProduct].EvilnessEffectPoint;

            Products[_currentProduct].ProductPrice = (ulong)(Products[_currentProduct].ProductPrice * 1.25f);
            Products[_currentProduct].EvilnessEffectPoint += 1;
            Products[_currentProduct].ProductLevel++;

            SaveProductData();
            LoadProductData();

            print("alındı");
        }
        else
        {
            print("Para yetersiz");
        }
        transform.GetComponent<Image>().sprite = Products[_currentProduct].ProductImage;
        transform.GetComponentInChildren<TextMeshProUGUI>().text = Products[_currentProduct].ProductName + "\n" + Products[_currentProduct].ProductPrice;
    }

    public void SaveProductData()
    {
        PlayerPrefs.SetInt(nameof(_currentProduct), _currentProduct);
        PlayerPrefs.SetInt(Products[_currentProduct].ProductName, Products[_currentProduct].ProductLevel);
        PlayerPrefs.SetString("ProductPrice", Products[_currentProduct].ProductPrice.ToString());
        PlayerPrefs.SetInt("EvilnessEffectPoint", Products[_currentProduct].EvilnessEffectPoint);
    }
    public void LoadProductData()
    {
        _currentProduct = PlayerPrefs.GetInt(nameof(_currentProduct));
        Products[_currentProduct].ProductLevel = PlayerPrefs.GetInt(Products[_currentProduct].ProductName);
        Products[_currentProduct].ProductLevel = PlayerPrefs.GetInt(Products[_currentProduct].ProductName);
        Products[_currentProduct].ProductPrice = ulong.Parse(PlayerPrefs.GetString("ProductPrice"));
        Products[_currentProduct].EvilnessEffectPoint = PlayerPrefs.GetInt("EvilnessEffectPoint");
    }

    private void OnApplicationQuit()
    {
        //SaveProductData();
    }
}
