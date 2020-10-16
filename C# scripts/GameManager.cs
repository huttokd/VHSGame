using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public Canvas WinCanvas;
    public Canvas LoseCanvas;


    public void GameWin()
    {
        Time.timeScale = 0f;
        WinCanvas.gameObject.SetActive(true);


    }


    public void GameLose()
    {
        Time.timeScale = 0f;
        LoseCanvas.gameObject.SetActive(true);



    }










}
