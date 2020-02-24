using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SelectionInfo : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Animator>().enabled = false;
    }
    public void Selected()
    {
        GetComponent<Animator>().enabled = false;
        if (GetComponent<Animator>().enabled == false) { GetComponent<Animator>().enabled = true; }
        GetComponent<Animator>().Play("Flip", 0);
        Synonym.selected = true;
        Synonym.buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
