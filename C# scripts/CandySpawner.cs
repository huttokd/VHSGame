using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public GameObject newCandy;
    float nextSpawn;
    float spawnTime;

    float minTime = 2f;
    float maxTime = 5f;
    Color nextColor;



    void Start()
    {

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
        SetNextColor();
        spawnTime = Time.time;
        nextSpawn = Random.Range(minTime, maxTime);
        GameObject temp = Instantiate(newCandy, transform.position, Quaternion.identity);
        temp.gameObject.GetComponent<MeshRenderer>().material.color = nextColor;
    }

    void SetNextColor()
    {
        int i = Random.Range(0, 5);
        if (i == 0)
        {
            nextColor = Color.red;
        }
        else if (i == 1)
        {
            nextColor = Color.blue;
        }
        else if (i == 2)
        {
            nextColor = Color.green;
        }
        else if (i == 3)
        {
            nextColor = Color.yellow;
        }
        else if (i == 4)
        {
            nextColor = Color.magenta;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

}
