using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDelete : MonoBehaviour
{
    public GameObject floor;
    public TapeSpawner[] spawners;
    public AudioSource buzz;
    public AudioSource song;
    public GameObject ppVolume;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ppVolume.SetActive(true);
            Destroy(floor);
            song.Stop();
            buzz.Play();
            foreach (TapeSpawner tapeSpawner in spawners)
            {
                tapeSpawner.gameObject.SetActive(true);
            }
        }



    }


}
