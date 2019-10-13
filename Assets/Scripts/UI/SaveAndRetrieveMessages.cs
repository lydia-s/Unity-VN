using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class SaveAndRetrieveMessages : MonoBehaviour
{
    
    public static HashSet<string> contactMsgs = new HashSet<string>();
    GameObject msgContainer;//the content message container
    public TextMeshProUGUI avatarName;//the avatar name


    public void SaveMsgHistory() {
        string name = avatarName.text.ToString();
        

        if (contactMsgs.Contains(name))
        {
            msgContainer = GameObject.Find("MessageContainer");//if message container already exists its name will be personalised
            Debug.Log("Overwritten existing container");
            UpdateMsgPrefab(msgContainer, name);

        }
        else {
            msgContainer = GameObject.Find("MessageContainer");//if new container
            Debug.Log("Saved new container");
            SaveMsgPrefab(msgContainer, name);
            contactMsgs.Add(name);
    

        }
        
    }
    [MenuItem("Examples/Create Prefab")]
    public void SaveMsgPrefab(GameObject gameObject, string name) {
        string localPath = "Assets/" + "RuntimeSaves/"+ name + "MsgContainer" + ".prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction);


    }
    public void UpdateMsgPrefab(GameObject gameObject, string name) {
        string localPath = "Assets/" + "RuntimeSaves/" + name + "MsgContainer" + ".prefab";
        AssetDatabase.DeleteAsset(localPath);
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction);


    }
    [MenuItem("Examples/Create Prefab", true)]
    static bool ValidateCreatePrefab()
    {
        return Selection.activeGameObject != null && !EditorUtility.IsPersistent(Selection.activeGameObject);
    }
   
}
