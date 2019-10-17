using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class SaveAndUpdateMessages : MonoBehaviour
{


    GameObject msgContainer;//the content message container
    public TextMeshProUGUI avatarName;//the avatar name
    public GameObject received = null;
    public GameObject sent = null;
    public GameObject messageContainer;//the grandparent of where the message will go

    /*
     * We need in this class:
     * A method that saves each message to a file containing messages
     * The file will contain information in the format: messageContent | messageType \n
     * Everytime the messenger screen is loaded the file content will be loaded and processed into text to display in game objects
     */

    //Called when a message is posted
    public void SaveMessageToFile(string messageContent, string messageType) {
        string localPath = "Assets/" + "RuntimeSaves/" + avatarName.text.ToString() + "MsgContainer.txt";

        if (!File.Exists(localPath)) {
            File.Create(localPath).Dispose();
        }
        using (StreamWriter sw = File.AppendText(localPath))
        {
            sw.WriteLine(messageContent + "|" + messageType);
            sw.Flush();
            sw.Close();
        }

    }

    //Called when the messenger screen is opened
    public void LoadMessagesFromFile() {
        string localPath = "Assets/" + "RuntimeSaves/" + avatarName.text.ToString() + "MsgContainer.txt";
        if (!File.Exists(localPath))
        {
            File.Create(localPath).Dispose();
            return;
        }

        StreamReader inp_stm = new StreamReader(localPath);

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            string[] message = inp_ln.Split('|');
            if (message[1] == "Received")
            {
                
                gameObject.GetComponent<GenerateMessage>().CreateMessage(received,message[0]);
            }
            else
            {
                
                gameObject.GetComponent<GenerateMessage>().CreateMessage(sent, message[0]);
            }
            // Do Something with the input. 
        }
        inp_stm.Close();
    }



    void Start()
    {
        LoadMessagesFromFile();
        
    }


}
