using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCRController : MonoBehaviour
{

    bool hasTape = false;
    bool TapeDone = false;
    [SerializeField] int serial;
    public Material[] screens;
    float updateScreenTime = 2f;
    float startScreenTime = 0f;
    public GameObject screenMat;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTape && Time.time > updateScreenTime + startScreenTime)
        {
            SetNewScreen();
        }




    }


    void SetNewScreen()
    {
        int i = Random.Range(1, screens.Length);
        screenMat.GetComponent<Renderer>().material = screens[i];
        startScreenTime = Time.time;
    }

    public void SwapTape()
    {
        if (!hasTape && FindObjectOfType<ItemHold>().GetHoldingTape())
        {
            InsertTape();
        }
        else if (hasTape)
        {
            RemoveTape();
        }
    }

    public void InsertTape()
    {
        if (!hasTape)
        {
            FindObjectOfType<ItemHold>().InsertTape();
            hasTape = true;
            RewindTape();
            SetNewScreen();
            audio.Play();

        }


    }


    public void RewindTape()
    {
            FindObjectOfType<TimersController>().GenerateTimer(serial);




    }

    public void RemoveTape()
    {
        CheckTapeDone();
        if (FindObjectOfType<ItemHold>().GetHoldingStatus() == false && TapeDone) 
        {
            audio.Play();
            hasTape = false;
            TapeDone = false;
            float percent = FindObjectOfType<TimersController>().RemoveTimer(serial);
            FindObjectOfType<ItemHold>().EjectTape(percent);
            screenMat.GetComponent<Renderer>().material = screens[0];
        }
    }

    void CheckTapeDone()
    {
        if (FindObjectOfType<TimersController>().CheckIfDone(serial))
        {
            TapeDone = true;
        }    
    }

}
