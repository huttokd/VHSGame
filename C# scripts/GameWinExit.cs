using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinExit : MonoBehaviour
{

    public Animator anim;
    
    bool doorOpen = false;

    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.gameObject.CompareTag("Key"))
        {
            OpenDoor();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player") && doorOpen)
        {
            SceneManager.LoadScene("SecondScene");
           // FindObjectOfType<GameManager>().GameWin();
        }
    }



    public void UseKey()
    {
        if (!doorOpen && FindObjectOfType<ItemHold>().GetHoldingKey())
        {

            doorOpen = true;
            OpenDoor();
            FindObjectOfType<ItemHold>().InsertTape();
            this.gameObject.layer = 2;

        }

    }


    void OpenDoor()
    {
        //anim.enabled = true;
        anim.SetTrigger("EventTrigger");
        doorOpen = true;
     
    }

    void StopAnimation()
    {

    }



}
