using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UnityEditorScript : EditorWindow
{
    /*
    * GetMsgContainer gets the path of the corresponding message container and returns an instantiated game object
    */
    public GameObject GetMsgContainer(string name)
    {
        GameObject pPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/RuntimeSaves/" + name + "MsgContainer.prefab", typeof(GameObject));
        Debug.Log(name + "MsgContainer");
        GameObject pNewObject = Instantiate(pPrefab) as GameObject;
        Debug.Log("found and instantiated prefab");
        return pNewObject;
    }
    //[MenuItem("Examples/Create Prefab")]
    public void SaveMsgPrefab(GameObject gameObject, string name)
    {
        string localPath = "Assets/" + "RuntimeSaves/" + name + "MsgContainer" + ".prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction);


    }
    public void UpdateMsgPrefab(GameObject gameObject, string name)
    {
        string localPath = "Assets/" + "RuntimeSaves/" + name + "MsgContainer" + ".prefab";
        AssetDatabase.DeleteAsset(localPath);
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction);


    }
    //[MenuItem("Examples/Create Prefab", true)]
    static bool ValidateCreatePrefab()
    {
        return Selection.activeGameObject != null && !EditorUtility.IsPersistent(Selection.activeGameObject);
    }
}
