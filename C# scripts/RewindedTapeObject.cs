using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindedTapeObject : MonoBehaviour
{

    float rewindPercent;
    float longTime = -0.75f;
    float mediumTime = -.5f;
    float lowTime = 1;
    int serial;
    public Material red;
    public Material blue;
    public Material green;

    // Start is called before the first frame update
    void Start()
    {
        serial = Random.Range(0, 3);
        SetColor();

    }

    public void SetColor()
    {
        if (serial == 0)
        {
            gameObject.GetComponent<Renderer>().material = red;
        }
        else if (serial == 1)
        {
            gameObject.GetComponent<Renderer>().material = blue;
        }
        else 
        {
            gameObject.GetComponent<Renderer>().material = green;
        }
    }


    public void SetRewindPercent(float percent)
    {
        rewindPercent = percent;
    }

    public float GetRewindPercent()
    {
        Debug.Log(rewindPercent);
        if (rewindPercent > .9)
        {
            return longTime;
        }
        else if(rewindPercent > .2)
        {
            return mediumTime;
        }
        else
        {
            return lowTime;
        }


        return rewindPercent;




    }

    public int GetSerial()
    {
        return serial;
    }


}
