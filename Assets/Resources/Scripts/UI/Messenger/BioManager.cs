using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BioManager : MonoBehaviour
{
    public GameObject bio;
    TextMeshProUGUI bioInfo;

    private void Start()
    {
        
    }

    public void ShowBioPopup() {

        bio.SetActive(true);
    }
    public void HideBioPopup()
    {

        bio.SetActive(false);
    }

}
