using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateMessage : MonoBehaviour
{
   // public TextMeshProUGUI inputText = null;
    public GameObject received;
    public GameObject sent;
    public GameObject placeMessage = null;
    public GameObject savePlace = null;//where the saveandupdatemessages script is attached
    public TextMeshProUGUI avatarName;

    private void Start()
    {

    }

    //for loading new messages
    public void CreateMessage(string message, string messageType) {
        Debug.Log(message);
        if (messageType == "Sent")
        {
            GameObject msg = Instantiate(sent) as GameObject;
            msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = message;
            msg.transform.SetParent(placeMessage.transform, false);
            msg.name = sent.name;
        }
        else {
            GameObject msg = Instantiate(received) as GameObject;
            msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = message;
            msg.transform.SetParent(placeMessage.transform, false);
            msg.name = received.name;
        }
        
    }
    //for loading old messages from files
    public void CreateMessage(GameObject messageBoxType, string message)
    {
        GameObject msg = Instantiate(messageBoxType) as GameObject;//instantiate message 
        msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = message;//set test
        msg.transform.SetParent(placeMessage.transform, false);//set parent
        msg.name = messageBoxType.name;
    }

}
