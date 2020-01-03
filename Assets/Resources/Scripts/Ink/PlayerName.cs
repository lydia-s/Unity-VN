using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class PlayerName : MonoBehaviour
{
    public TextMeshProUGUI nameInput;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown("return")) {
            InkTestingScript.playerName = nameInput.text;
            panel.SetActive(false);
            enabled = false;
        }
    }


    
}
