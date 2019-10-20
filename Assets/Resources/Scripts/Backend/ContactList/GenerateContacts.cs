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
     
        SetContact("Helen", 23, "Musician, nature lover", profile_img);
        SetContact("John", 21, "Painter, writer, artist", profile_img1);

    }
}
