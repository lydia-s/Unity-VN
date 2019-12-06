using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageLists : MonoBehaviour
{
    /*
     * So this class is meant to store the message history and then pass that data to the save system
     * Clear the lists on exit 
     */
    public List<string> messageHistory1;//in the format: message | sent
    public List<string> messageHistory2;
    public List<string> messageHistory3;
    public static bool IsLoaded = false;

    private void Start()
    {
        messageHistory1.Clear();
        if (IsLoaded == true) {
            PlayerData data = SaveSystem.LoadData();
            messageHistory1 = data.messageHistory1;
        }
    }
    //append a message to a list
    public void SaveMessageToList(string message, string tag) {
        Debug.Log(message + " | " + tag + "Called in MessageLists");
        string messageAndTag = message + "|" + tag;
        messageHistory1.Add(messageAndTag);//add this to list
    }
    public void LoadMessagesFromList() {

        GameObject phone = GameObject.Find("Phone");

        foreach (string message in messageHistory1) {
            string[] splitMessage = message.Split('|');
            phone.GetComponent<GenerateMessage>().CreateMessage(splitMessage[0], splitMessage[1]);
        }
        
    }
   
}
