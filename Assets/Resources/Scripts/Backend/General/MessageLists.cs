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
    public string playerName = "";
    public Dictionary<string, string> storyPositions = new Dictionary<string, string>();//string name, string saveState
    public static bool IsLoaded = false;

    private void Start()
    {
        messageHistory1.Clear();
        if (IsLoaded == true) {
            PlayerData data = SaveSystem.LoadData();
            messageHistory1 = data.messageHistory1;
            messageHistory2 = data.messageHistory2;
            messageHistory3 = data.messageHistory3;
            storyPositions = data.storyPositions;
            playerName = data.playerName;
        }
    }
    public void SaveStoryState(string name, string storyState) {
        if (storyPositions.ContainsKey(name))
        {
            storyPositions.Remove(name);
            storyPositions.Add(name, storyState);
        }
        else {
            storyPositions.Add(name, storyState);
        }
        
    }

    /**
     * Append a message to a list
     * Would suggest not hardcoding the names later on
     * Same with LoadMessagesFromList, change hardcoding
     */
    public void SaveMessageToList(string message, string tag, string name) {
        string messageAndTag = message + "|" + tag;
        switch (name) {
            case "Group 21":
                messageHistory1.Add(messageAndTag);//add this to list
                break;
        }
        
    }
    public void LoadMessagesFromList(string name) {
        switch (name) {
            case "Group 21":
                LoadMessages(messageHistory1);
                break;
        }
        
    }
    public void LoadMessages(List<string> listName) {
        GameObject choices = GameObject.Find("Choices");
        foreach (string message in listName)
        {
            string[] splitMessage = message.Split('|');
            choices.GetComponentInChildren<GenerateMessage>().LoadOldMessages(splitMessage[0], splitMessage[1]);
        }
    }
   
}
