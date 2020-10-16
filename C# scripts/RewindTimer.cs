using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class RewindTimer : MonoBehaviour
{
    float clockPercent;
    float minRewindTime = 12;
    float maxRewindTime = 20;
    float timer;
    float endTime;
    bool timerActive;
    
    [SerializeField] Image clockHand;
    int serial;
    public TextMeshProUGUI VCRSerial;

    private void Start()
    {
        StartClock();
    }

    private void Update()
    {
        UpdateClock();
    }

    void StartClock()
    {
        timer = Random.Range(minRewindTime, maxRewindTime);
       
        //startTime = Time.time;
        endTime = Time.time + timer;
        timerActive = true;

    }


    void UpdateClock()
    {
        if (endTime > Time.time && timerActive)
        {

            clockPercent = (endTime - Time.time) / (timer);
            float clockHandAngle = 360 * clockPercent;

            clockHand.rectTransform.eulerAngles = (new Vector3(0, 0, clockHandAngle));

            // Debug.Log(clockHandAngle);
            //call for NPC to leave
        }
        else
        {
            StopClock();
           // FindObjectOfType<TaskManager>().CompleteTaskFailure();
        }

    }

    public void StopClock()
    {
        clockHand.rectTransform.eulerAngles = (new Vector3(0, 0, 0));
  
        timerActive = false;
        clockPercent = 100;

    }

    public float TimerLeft()
    {

        return clockPercent;
    }

    public void SetSerial(int i)
    {
        serial = i;
        VCRSerial.text = "VCR " + i;
    }

    public int GetSerial()
    {
        return serial;
    }

    public bool GetTimerActive()
    {
        return !timerActive;
    }

}
