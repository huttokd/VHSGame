using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUnlock : MonoBehaviour
{

    public int requiredScore;
    public TextMeshProUGUI requiredScoreText;



    public void TryOpenDoor()
    {
        if (FindObjectOfType<GameStats>().GetScore()>= requiredScore)
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateScoreText(int i)
    {
        int temp = Mathf.Clamp(requiredScore - i, 0, requiredScore);
        requiredScoreText.text = "To unlock, rewind " + temp + " more tapes";



    }



}
