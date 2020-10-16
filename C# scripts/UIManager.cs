using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI managerHappiness;
    [SerializeField] TextMeshProUGUI interactText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateManagerHappiness(float i)
    {
        managerHappiness.text = "Manager Happineess: " + (int)i;
    }
    public void DisplayInteractText(string s)
    {
        interactText.text = s;
    }

}
