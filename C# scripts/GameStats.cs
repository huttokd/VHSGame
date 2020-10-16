using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{

    float managerHappinessFromTurnIn;
    float managerHappiness;
    float maxManagerHappiness = 100;
    int tapesExisting = 0;
    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        managerHappinessFromTurnIn = maxManagerHappiness;
        UpdateScores();


    }

  

    public void updateManagerHappiness(float i)
    {
        managerHappinessFromTurnIn = Mathf.Clamp(managerHappinessFromTurnIn + i, 0, maxManagerHappiness);
        CalculateManagerHappiness();
    }

    void CalculateManagerHappiness()
    {
        managerHappiness = Mathf.Clamp(100 - (tapesExisting/3), 0, maxManagerHappiness);

        if (managerHappiness == 0)
        {
            FindObjectOfType<GameManager>().GameLose();
        }

        FindObjectOfType<UIManager>().UpdateManagerHappiness(managerHappiness);
    }


    public void IncrementTapeCount()
    {
        tapesExisting++;
        CalculateManagerHappiness();
    }

    public void DecrementTapeCount()
    {
        tapesExisting--;
        CalculateManagerHappiness();
        score++;
        UpdateScores();
        

    }

    void UpdateScores()
    {
        ScoreUnlock[] temp = FindObjectsOfType<ScoreUnlock>();
        foreach (ScoreUnlock scoreUnlock in temp)
        {
            scoreUnlock.UpdateScoreText(score);

        }
    }

    public int GetScore()
    {

        return score;
    }



}
