using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadContacts : MonoBehaviour
{
    public GameObject contactList;
    public GameObject contactButton;

    
    // Start is called before the first frame update
    void Start()
    {

        PopulateList();

    }

    //add each person to a button in a list
    public void PopulateList() {
        GenerateContacts gC = GetComponent<GenerateContacts>();
        gC.AddContacts();
        foreach (KeyValuePair<string, ContactInfo> entry in gC.contacts)
        {
            GetContact(entry.Key, gC.contacts);//add each contact to list
            
        }

    }

    //Extract a contact from a dictionary and instantiate button with info
    public void GetContact(string id, Dictionary<string, ContactInfo> contacts) {
        
        ContactInfo person = contacts[id];
        string name = person.name;
        Sprite img = person.avatar;
        GameObject contact = Instantiate(contactButton) as GameObject;
        contact.name = name;
        //contact.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(name);//set name to button
        contact.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = name;
        contact.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = img;//set avatar to button
        contact.transform.SetParent(contactList.transform, false);//add to list view
    }

}
