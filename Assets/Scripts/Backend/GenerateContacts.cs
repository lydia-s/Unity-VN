using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateContacts : MonoBehaviour
{
    //Contact images
    public Sprite geeki_img;
    public Sprite pablo_img;
    //Contact message histories
    public ArrayList geekiMsgs = new ArrayList();
    public ArrayList pabloMsgs = new ArrayList();
    //Contact Dictionary
    public Dictionary<string, ContactInfo> contacts = new Dictionary<string, ContactInfo>();

    //Set contact information
    public void SetContact(string name, int age, string bio, Sprite avatar, ArrayList msgHis)
    {
        ContactInfo cI = new ContactInfo();
        cI.name = name;
        cI.bio = bio;
        cI.age = age;
        cI.avatar = avatar;
        cI.msgHistory = msgHis;
        contacts.Add(name, cI);
    }

    //Add contact to dictionary
    public void AddContacts() {

        SetContact("Geeki", 23, "Musician, nature lover", geeki_img, geekiMsgs);
        SetContact("Pablo", 21, "Painter", pablo_img, pabloMsgs);
    }
}
