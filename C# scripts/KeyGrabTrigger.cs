using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGrabTrigger : MonoBehaviour
{
    public List<GameObject> CandySpawners;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject spawner in CandySpawners)
            {
                spawner.SetActive(true);
            }
        }
    }


}
