using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StartScreen : MonoBehaviour
{

    public GameObject creditsText;
    public GameObject creditsButton;
    public GameObject creditsBackButton;
    public GameObject startButton;


    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CreditsButton()
    {
        creditsBackButton.SetActive(true);
        creditsButton.SetActive(false);
        startButton.SetActive(false);
        creditsText.SetActive(true);
    }

    public void CreditsBackButton()
    {
        creditsBackButton.SetActive(false);
        creditsButton.SetActive(true);
        startButton.SetActive(true);
        creditsText.SetActive(false);
    }



}
