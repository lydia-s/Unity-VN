using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class LoadPostsContent : MonoBehaviour
{
    public GameObject content;
    public TextMeshProUGUI avatarName;
    // Start is called before the first frame update
    void Start()
    {
        LoadPrefab("GameObjects/MusicTrack");
    }

    public void LoadPrefab(string name) {
        GameObject post = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
        post.transform.SetParent(content.transform, false);//set parent to content gameobject
        post.name = name;
    }

    //call after instantiating a new post so that it can be saved to a file and reloaded
    public void SaveLatestPostToFile()
    {
        int numChild = content.transform.childCount-1;//get last child index
        string postLocation = "GameObjects/" + content.transform.GetChild(numChild).name;

        string localPath = Application.dataPath + "/" + avatarName.text + "Posts.txt";

        if (!File.Exists(localPath))
        {
            File.Create(localPath).Dispose();
        }
        using (StreamWriter sw = File.AppendText(localPath))
        {
            sw.WriteLine(postLocation);
            sw.Flush();
            sw.Close();
        }

    }
    public void LoadPostsFromFile()
    {
        string localPath = Application.dataPath + "/" + avatarName.text + "Posts.txt";
        if (!File.Exists(localPath))
        {
            File.Create(localPath).Dispose();
            return;
        }

        StreamReader inp_stm = new StreamReader(localPath);

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            string post = inp_ln;
            LoadPrefab(post);
           
        }
        inp_stm.Close();
    }



}
