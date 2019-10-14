using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateContacts : MonoBehaviour
{
    //Contact images
    public Sprite profile_img;

    //Contact message histories
    public ArrayList contactMsgs = new ArrayList();
    //Contact Dictionary
    public Dictionary<string, ContactInfo> contacts = new Dictionary<string, ContactInfo>();

    public TextMeshProUGUI name;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AddContacts();

        }
    }

    //Add contact to dictionary
    public void AddContacts() {
        if (contacts.ContainsKey(name.text.ToString()))
        {
            return;
        }
        else {
            
            SetContact(name.text.ToString(), 23, "Empty", profile_img, contactMsgs);
            LoadContacts loadContacts = this.GetComponent<LoadContacts>();
            loadContacts.GetContact(name.text.ToString(), contacts);
        }
        
        /*SetContact("Jenny", 23, "Musician, nature lover", geeki_img, geekiMsgs);
        SetContact("Pablo", 21, "Painter", pablo_img, pabloMsgs);
        SetContact("Ben", 24, "Professional Illustrator", ky_img, kyMsgs);*/
    }
}
