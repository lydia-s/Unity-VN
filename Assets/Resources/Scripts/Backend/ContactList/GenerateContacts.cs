using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateContacts : MonoBehaviour
{
    //Contact images
    public Sprite profile_img;
    public Sprite profile_img1;
    //Contact Dictionary
    public Dictionary<string, ContactInfo> contacts = new Dictionary<string, ContactInfo>();


    //Set contact information
    public void SetContact(string name, int age, string bio, Sprite avatar)
    {
        ContactInfo cI = new ContactInfo();
        cI.name = name;
        cI.bio = bio;
        cI.age = age;
        cI.avatar = avatar;
        contacts.Add(name, cI);
    }

    //Add contact to dictionary
    public void AddContacts() {
     
        SetContact("Group 21", 23, "Group chat for our project :P", profile_img);
    }
}
