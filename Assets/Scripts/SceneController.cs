using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _creditsUI;
    [SerializeField] private GameObject _menuQuestion;
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OpenCreditsUI()
    {
        _creditsUI.SetActive(true);
    }
    public void CloseCreditsUI()
    {
        _creditsUI.SetActive(false);
    }
    public void OpenMenuQuestionUI()
    {
        _menuQuestion.SetActive(true);
    }
    public void CloseMenuQuestionUI()
    {
        _menuQuestion.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene("FirstScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
