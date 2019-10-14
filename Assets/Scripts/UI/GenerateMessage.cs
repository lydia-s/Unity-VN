using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateMessage : MonoBehaviour
{
    public TextMeshProUGUI inputText = null;
    public GameObject messageBox = null;
    public GameObject placeMessage = null;


    public void CreateMessage() {
       
        GameObject msg = Instantiate(messageBox) as GameObject;
        msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(inputText.text);
        msg.transform.SetParent(placeMessage.transform.GetChild(0), false);
        
    }
    
}
