using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class Reset : MonoBehaviour
{
    public GameObject gOb;
   
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ResetStory();
        }
    }
    public void ResetStory()
    {
        PlayerPrefs.DeleteKey("inkSaveState");
        gOb.GetComponent<InkTestingScript>().ResetState();
        gOb.GetComponent<InkTestingScript>().RefreshUI();
    }
 

}
