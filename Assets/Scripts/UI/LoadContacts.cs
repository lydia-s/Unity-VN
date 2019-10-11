using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadContacts : MonoBehaviour
{
    public GameObject contactList = null;
    public GameObject contactButton = null;
    ArrayList ids = new ArrayList();
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateContacts gC = this.GetComponent<GenerateContacts>();
        gC.AddContacts();
        GetContact("Geeki", gC.contacts);
        GetContact("Pablo", gC.contacts);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //add name and avatar image to a button in a list
    public void PopulateList() {
        
    }
   
    //Extract a contact from a data structure
    public void GetContact(string id, Dictionary<string, ContactInfo> contacts) {
        
        
        ContactInfo person = contacts[id];
        name = person.name;
        Sprite img = person.avatar;
        GameObject contact = Instantiate(contactButton) as GameObject;
        
        contact.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(name);//set name to button
        contact.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = img;//set avatar to button
        contact.transform.SetParent(contactList.transform, false);//add to list view
    }

}
