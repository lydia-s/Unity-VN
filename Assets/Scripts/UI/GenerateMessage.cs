using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateMessage : MonoBehaviour
{
    public TextMeshProUGUI inputText = null;
    public GameObject messageBox = null;
    public GameObject placeMessage = null;
    public GameObject savePlace = null;//where the saveandupdatemessages script is attached

    //for loading new messages
    public void CreateMessage() {
       
        GameObject msg = Instantiate(messageBox) as GameObject;
        msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(inputText.text);
        msg.transform.SetParent(placeMessage.transform.GetChild(0), false);
        msg.name = messageBox.name;
        savePlace.GetComponent<SaveAndUpdateMessages>().SaveMessageToFile(inputText.text.ToString(), messageBox.name.ToString());
    }
    //for loading old messages from files
    public void CreateMessage(GameObject messageBoxType, string message)
    {
        
        GameObject msg = Instantiate(messageBoxType) as GameObject;
        msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(message);
        msg.transform.SetParent(placeMessage.transform.GetChild(0), false);
        msg.name = messageBox.name;
    }

}
