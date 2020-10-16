using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    UIManager uIManager;
    new public Camera camera;
    ItemHold itemHold;
    RaycastHit hit;


    int layerMask;


    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 9;
        layerMask += 1 << 2;
        layerMask = ~layerMask;
        itemHold = gameObject.GetComponent<ItemHold>();
        uIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateInteractCast();


        if (Input.GetMouseButtonDown(0))
        {
            MouseLeftButton();
        }





    }

    private void UpdateInteractCast()
    {
        string interactText = null;
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Physics.Raycast(ray, out hit, 8f, layerMask);
            if (hit.collider != null)
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Tape":
                        interactText = "Pick Up VHS";
                        break;
                    case "Money":
                        interactText = "Pick Up Money";

                        break;
                    case "Soda":
                        interactText = "Pick Up Diet Soda";

                        break;
                    case "Mentos":
                        interactText = "Pick Up Mentos";
                        break;
                    case "RewoundTape":
                        interactText = "Pick Up Rewound Tape";
                        break;
                    case "Key":
                        interactText = "Pick Up Key";
                        break;
                case "PickUp":
                    interactText = "Pick Up Item";
                    break;
                case "LockedDoor":
                    interactText = "Attempt To Open Door";
                    break;
                case "VCR":
                    interactText = "Interact with VCR";
                    break;
                case "TurnInButton":
                    interactText = "Turn In Tapes";
                    break;
                case "ExitDoor":
                    interactText = "Attempt Escape";
                    break;
                case "Win":
                    interactText = "Break Free";
                    break;
                case "Vend":
                    interactText = "Buy Item with coin";

                    break;
                default:
                        interactText = "";

                        break;

                }


            }
            else
            {
                interactText = "";
            }
        
        uIManager.DisplayInteractText(interactText);


    }

    private void MouseLeftButton()
    {

       // Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
       // RaycastHit hit;
       // Physics.Raycast(ray, out hit, 8f, layerMask);
        //Debug.DrawRay(ray, Color.red, 3f);
        
        GameObject gameObject;
        if (hit.collider != null)
        {
            switch (hit.collider.gameObject.tag)
            {
                case "Tape":
                    itemHold.PickupItem(hit.collider.gameObject);
                   
                        break;
                case "Money":
                    itemHold.PickupItem(hit.collider.gameObject);

                    break;
                case "Soda":
                    itemHold.PickupItem(hit.collider.gameObject);

                    break;
                case "Mentos":
                    itemHold.PickupItem(hit.collider.gameObject);

                    break;
                case "RewoundTape":
                    itemHold.PickupItem(hit.collider.gameObject);
                    
                    break;
                case "Key":
                    itemHold.PickupItem(hit.collider.gameObject);
                   
                    break;
                case "PickUp":
                    itemHold.PickupItem(hit.collider.gameObject);
                  
                    break;
                case "LockedDoor":
                    hit.collider.gameObject.GetComponent<ScoreUnlock>().TryOpenDoor();

                    break;
                case "ExitDoor":
                    hit.collider.gameObject.GetComponent<GameWinExit>().UseKey();
                    break;
                case "VCR":
                    hit.collider.gameObject.GetComponent<VCRController>().SwapTape();
                    break;
                case "TurnInButton":
                    hit.collider.gameObject.GetComponent<TurnInButton>().TurnIn();
                    break;
                case "Win":
                    FindObjectOfType<GameManager>().GameWin();
                    break;
                case "Vend":
                    hit.collider.gameObject.GetComponent<VendingMachine>().InsertCoin();
                    break;
                default:
                    break;

            }

            // Debug.Log(hit.collider.gameObject.tag);
        }

    }
}