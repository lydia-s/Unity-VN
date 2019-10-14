using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows;

public class SaveAndUpdateMessages : MonoBehaviour
{
    
    
    GameObject msgContainer;//the content message container
    public TextMeshProUGUI avatarName;//the avatar name

/*
    public void SaveMsgHistory() {
        string name = avatarName.text.ToString();
        string localPath = "Assets/" + "RuntimeSaves/" + name + "MsgContainer" + ".prefab";

        if (File.Exists(localPath))
        {
            msgContainer = GameObject.Find("MessageContainer");
            Debug.Log("Overwritten existing container");
           // UpdateMsgPrefab(msgContainer, name);

        }
        else {
            msgContainer = GameObject.Find("MessageContainer");//if new container
            Debug.Log("Saved new container");
            //SaveMsgPrefab(msgContainer, name);
    
        }
        
    }
    */

   
}
