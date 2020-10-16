using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHold : MonoBehaviour
{

    GameObject heldObject;
    public GameObject rewoundTape;
    public Transform holdPosition;
    string tag;
    bool holdingObject = false;
    bool holdingTape = false;
    bool holdingMoney = false;
    bool holdingKey = false;

    public float throwForce = 10f;
   // public Collider holdCollider;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DropItem();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ThrowItem();
        }

        if (holdingObject)
        {
           // heldObject.transform.position = holdPosition.position;
        }


    }

    void ThrowItem()
    {
        if (holdingObject)
        {
            holdPosition.DetachChildren();
          heldObject.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            heldObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject.tag = tag;
            heldObject.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
            if (heldObject.gameObject.GetComponent<Renderer>() != null)
            {
                heldObject.gameObject.GetComponent<Renderer>().material.SetFloat("GlowOn", 0);
            }
            holdingObject = false;
            holdingTape = false;
            heldObject = null;
          //  holdCollider.enabled = false;

        }
    }

    public bool GetHoldingTape()
    {
        return holdingTape;
    }

    public bool GetHoldingMoney()
    {
        return holdingMoney;
    }

    public bool GetHoldingKey()
    {
        return holdingKey;
    }

public void PickupItem(GameObject holdObject)
    {
       
      if (heldObject == null && holdingObject == false)
        {
            if (holdObject.tag == "Tape")
            {
                holdingTape = true;
            }
            else if (holdObject.tag == "Money")
            {
                holdingMoney = true;
            }
            else if (holdObject.tag == "Key")
            {
                holdingKey = true;
            }
            // holdCollider.enabled = true;
            holdingObject = true;
            heldObject = holdObject;
            holdObject.gameObject.transform.parent = holdPosition;
            if (heldObject.gameObject.GetComponent<Renderer>() != null)
            {
                holdObject.gameObject.GetComponent<Renderer>().material.SetFloat("GlowOn", 1);
            }
            if (holdObject.gameObject.GetComponent<Rigidbody>() != null)
            {
              holdObject.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
                holdObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                tag = heldObject.tag;
                heldObject.tag = "Untagged";
            }
        }



    }


    public void DropItem()
    {
        if (heldObject != null)
        {
         //   holdCollider.enabled = false;

            holdPosition.DetachChildren();
          heldObject.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            heldObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            if (heldObject.gameObject.GetComponent<Renderer>() != null)
            {
                heldObject.gameObject.GetComponent<Renderer>().material.SetFloat("GlowOn", 0);
            }
            heldObject.tag = tag;
            heldObject = null;
            holdingObject = false;
            holdingTape = false;
            holdingMoney = false;
            holdingKey = false;
        }



    }


    public void InsertTape()
    {
        if (heldObject != null)
        {
            Destroy(heldObject);
            holdingObject = false;
            holdingTape = false;
            // holdCollider.enabled = false;
            holdingMoney = false;
            holdingKey = false;
        }
    }

    public void EjectTape(float percent)
    {
        if (!holdingObject)
        {
            GameObject newTape = Instantiate(rewoundTape, holdPosition.transform.position, Quaternion.identity);
           newTape.GetComponent<RewindedTapeObject>().SetRewindPercent(percent);
            PickupItem(newTape);
        }
    }

    public bool GetHoldingStatus()
    {
        return holdingObject;
    }

    
}
