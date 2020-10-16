using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeSpawner : MonoBehaviour
{
    
    public GameObject newTape;
    float nextSpawn;
    float spawnTime;

    float minTime = 8f;
    float maxTime = 14f;

    public AudioSource audio;

    void Start()
    {
       nextSpawn = Time.time + 3f;
    }

    
    void Update()
    {
    
        if (Time.time > nextSpawn + spawnTime)
        {
            SpawnTape();
        }



    }



    void SpawnTape()
    {
        spawnTime = Time.time;
        nextSpawn = Random.Range(minTime, maxTime);
        Instantiate(newTape, transform.position, Quaternion.identity);
        FindObjectOfType<GameStats>().IncrementTapeCount();
        audio.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }


}
