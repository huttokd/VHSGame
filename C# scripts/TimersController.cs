using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimersController : MonoBehaviour
{

    public GameObject timerTemplate;

    List<GameObject> activeTimers;
    public GameObject timerHolder;

    // Start is called before the first frame update
    void Start()
    {
        activeTimers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerateTimer(int i)
    {
        GameObject temp = Instantiate(timerTemplate, timerHolder.transform.position, Quaternion.identity);
        temp.transform.parent = timerHolder.transform;
        temp.GetComponent<RewindTimer>().SetSerial(i);
        activeTimers.Add(temp);



    }

    public float RemoveTimer(int i)
    {
        float percent = 0;
        GameObject tempTimer = null;
        List<GameObject> temp = activeTimers;
        foreach (GameObject timer in temp)
        {
            if (timer.GetComponent<RewindTimer>().GetSerial() == i)
            {
                tempTimer = timer;
                percent = timer.GetComponent<RewindTimer>().TimerLeft();
            }
        }
        if (tempTimer != null)
        {
            activeTimers.Remove(tempTimer);
            Destroy(tempTimer);
        }
        return percent;

    }

   public bool CheckIfDone(int i)
    {
        
        foreach (GameObject timer in activeTimers)
        {
            if (timer.GetComponent<RewindTimer>().GetSerial() == i)
            {
                return timer.GetComponent<RewindTimer>().GetTimerActive();
             
            }
        }
        return false;

    }
    

}
