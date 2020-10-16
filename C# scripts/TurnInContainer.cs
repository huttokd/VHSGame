using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInContainer : MonoBehaviour
{

    List<GameObject> turnInTapes;
    public int serial;

    // Start is called before the first frame update
    void Start()
    {
        turnInTapes = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RewoundTape") && other.gameObject.GetComponent<RewindedTapeObject>().GetSerial() == this.serial)
        {
            turnInTapes.Add(other.gameObject);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RewoundTape") && other.gameObject.GetComponent<RewindedTapeObject>().GetSerial() == this.serial)
        {
            turnInTapes.Remove(other.gameObject);
        }
    }

    public void TurnIn()
    {
        float turnInScore = 0;
        if (turnInTapes.Count > 0)
        {
            for (int i = turnInTapes.Count-1; i >= 0; i--)
            {
                turnInScore += turnInTapes[i].gameObject.GetComponent<RewindedTapeObject>().GetRewindPercent();
                GameObject temp = turnInTapes[i];
                turnInTapes.Remove(temp);
                Destroy(temp);
                FindObjectOfType<GameStats>().DecrementTapeCount();
            }
        }
        FindObjectOfType<GameStats>().updateManagerHappiness(turnInScore);
    }


}
