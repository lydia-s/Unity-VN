using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

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
        
        if (!SaveAndRetrieveMessages.contactMsgs.Contains(name.text.ToString()))//If container has not been saved for contact
        {
            
            GameObject msgCon = Instantiate(msgContainer) as GameObject;
            Debug.Log(msgCon.name);
            msgCon.name = "MessageContainer";
            msgCon.transform.SetParent(gameObject.transform.GetChild(0), false);
        }
        else {
            GameObject msgCon = GetMsgContainer();
            msgCon.name = "MessageContainer";
            msgCon.transform.SetParent(gameObject.transform.GetChild(0), false);
        }
    }
  /*
   * GetMsgContainer gets the path of the corresponding message container and returns an instantiated game object
   */
    public GameObject GetMsgContainer() {
        GameObject pPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/RuntimeSaves/" + name.text.ToString() + "MsgContainer.prefab", typeof(GameObject));
        Debug.Log(name.text.ToString() + "MsgContainer");
        GameObject pNewObject = Instantiate(pPrefab) as GameObject;
        Debug.Log("found and instantiated prefab");
        return pNewObject;
    }
    //set the new container as the 'content' for the scroll view
    public void ScrollViewSetContent() {
        content = transform.GetChild(0).GetChild(0).gameObject;//get the (granchild)content game object scroll view
        sRect.content = content.transform.gameObject.GetComponent<RectTransform>();
    }

}
