using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSet : MonoBehaviour
{
    Vector3 spawn;


    private void Start()
    {
        spawn = transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().UpdateSpawn(spawn);
        }
    }


    

}
