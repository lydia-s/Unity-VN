using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using System.Text.RegularExpressions;

public class PlayerName : MonoBehaviour
{
    /*
     * When loading the room scene, if it is a new game this script will enable the name entry panel
     * This is so a player can input their name
     */
    public TextMeshProUGUI nameInput;
    public TMP_InputField inputField;
    public GameObject panel;
    void Start()
    {
        inputField.characterLimit = 12;
        if (MessageLists.IsLoaded == false)
        {
            StartCoroutine(CheckName());
        }
        else
        {
            panel.SetActive(false);
        }

    }

    IEnumerator CheckName()
    {
        yield return new WaitUntil(()=> Input.GetKeyDown("return") && Regex.IsMatch(nameInput.text, @"[a-zA-Z]"));
        InkTestingScript.playerName = nameInput.text;
        panel.SetActive(false);
        Time.timeScale = 1f;
    }


    
}
