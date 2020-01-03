using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using System.Text.RegularExpressions;

public class PlayerName : MonoBehaviour
{
    public TextMeshProUGUI nameInput;
    public TMP_InputField inputField;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        inputField.characterLimit = 12;
    }
    private void Update()
    {
        if (MessageLists.IsLoaded == false) {
            Time.timeScale = 0f;

            if (Input.GetKeyDown("return") && Regex.IsMatch(nameInput.text, @"[a-zA-Z]"))//has to contain at least one character
            {
                InkTestingScript.playerName = nameInput.text;
                panel.SetActive(false);
                Time.timeScale = 1f;
                enabled = false;
            }

        }
        if (MessageLists.IsLoaded == true) {
            panel.SetActive(false);
        }

    }


    
}
