using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UI_Object;

    public void OpenUI()
    {
        UI_Object.SetActive(true);
    }
    public void CloseUI()
    {
        UI_Object.SetActive(false);
    }
}
