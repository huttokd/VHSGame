using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInButton : MonoBehaviour
{

    public TurnInContainer turnInContainer;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnIn()
    {
        turnInContainer.TurnIn();
        audio.Play();
    }


}
