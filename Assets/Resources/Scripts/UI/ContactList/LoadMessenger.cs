using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
/*
 * LoadMessenger is attached to a button and passes the contact's name and avatar to the CustomiseMessengerInfo script
 * It then loads the messenger scene
 */
public class LoadMessenger : MonoBehaviour
{
    public TextMeshProUGUI contact;
    public TextMeshProUGUI bio;
    public Image contactAvatar;
    public void LoadMessengerScreen()
    {
        //this is getting original prefab text not actual text but don't know why
        CustomiseMessengerInfo.contactName = contact.text.ToString();//gameobject.name
        CustomiseMessengerInfo.avatar = contactAvatar.sprite;
        //get list of message objects and populate list view content with them
        CustomiseMessengerInfo.contactBio = bio.text;
        SceneManager.LoadScene("Messenger");
    }
}
