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
            Debug.Log(msgCon.name);
            //We set this name the same each time so the message container can be found whatever the original name was
            msgCon.name = "MessageContainer";
            msgCon.transform.SetParent(gameObject.transform.GetChild(0), false);
        string localPath = "Assets/" + "RuntimeSaves/" + name.text.ToString() + "MsgContainer" + ".prefab";
        //SerializeToXMLFile<Object>(localPath, msgCon, true);
        //GameObject go = DeserializeFromXMLFile<GameObject>(localPath);
       //Debug.Log(go.name);





    }
    
   
    public bool SerializeToXMLFile<T>(string writePath, object serializableObject, bool overWrite = true)
    {
        if (UnityEngine.Windows.File.Exists(writePath) && overWrite == false)
            return false;
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (var writeFile = System.IO.File.Create(writePath))
        {
            serializer.Serialize(writeFile, serializableObject);
        }
        return true;
    }
    public static T DeserializeFromXMLFile<T>(string readPath)
    {
        if (!System.IO.File.Exists(readPath))
            return default(T);

        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (var readFile = System.IO.File.OpenRead(readPath))
            return (T)serializer.Deserialize(readFile);


    }

    //set the new container as the 'content' for the scroll view
    public void ScrollViewSetContent() {
        content = transform.GetChild(0).GetChild(0).gameObject;//get the (granchild)content game object scroll view
        sRect.content = content.transform.gameObject.GetComponent<RectTransform>();
    }

}
