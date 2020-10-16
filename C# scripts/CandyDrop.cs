using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDrop : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {

            Destroy(this.gameObject);
        }
    }


}
