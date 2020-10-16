using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public AudioSource audio;
    bool vended = false;
    public GameObject vendItem;
    public Transform createPos;

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Money") && !vended)
        {
            vended = true;
            DropItem();
            Destroy(collision.gameObject);
            this.gameObject.layer = 2;
        }
      
    }


    public void InsertCoin()
    {
        if (!vended && FindObjectOfType<ItemHold>().GetHoldingMoney())
        {

            vended = true;
            DropItem();
            FindObjectOfType<ItemHold>().InsertTape();
            this.gameObject.layer = 2;

        }

    }


    void DropItem()
    {
        CreateItem();
        audio.Play();
        

    }

    void CreateItem()
    {
        Instantiate(vendItem, createPos.position, Quaternion.identity);



    }


}
