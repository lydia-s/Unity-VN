using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

[System.Serializable]
public class CreateMessageContainer : MonoBehaviour
{
    
    public GameObject msgContainer;
    public ScrollRect sRect;//the scroll rect script attached to list view
    public TextMeshProUGUI name;
    GameObject content;//content game object
    // Start is called before the first frame update
    void Start()
    {
        CreateContainer();
        ScrollViewSetContent();
    }

    //create the container for the messages
    public void CreateContainer() {
            GameObject msgCon = Instantiate(msgContainer) as GameObject;
            //We set this name the same each time so the message container can be found whatever the original name was
            msgCon.name = "MessageContainer";
            msgCon.transform.SetParent(gameObject.transform.GetChild(0), false);

    }
    

    //set the new container as the 'content' for the scroll view
    public void ScrollViewSetContent() {
        content = transform.GetChild(0).GetChild(0).gameObject;//get the (granchild)content game object scroll view
        sRect.content = content.transform.gameObject.GetComponent<RectTransform>();
    }

}
