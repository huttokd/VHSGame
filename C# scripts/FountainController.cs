using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainController : MonoBehaviour
{

    [SerializeField] bool hasMentos = false;
    [SerializeField] bool hasSoda = false;
    public ParticleSystem fountain;

    public AudioSource audio;
    public AudioSource water;


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Mentos"))
        {
            hasMentos = true;
            Destroy(other.gameObject);
            audio.Play();
        }
        else if (other.gameObject.CompareTag("Soda"))
        {
            hasSoda = true;
            Destroy(other.gameObject);
            audio.Play();

        }
        else if (other.gameObject.CompareTag("Player") && hasMentos && hasSoda)
        {
            other.gameObject.GetComponent<PlayerController>().AddPushUp();
       

        }

        if (hasMentos && hasSoda)
        {
            fountain.Play();
            water.Play();
        }

    }


}
