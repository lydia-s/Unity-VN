using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomiseMessengerInfo : MonoBehaviour
{
    /*
     * CustomiseMessengerInfo personalises the components of a messenger scene to a specific person
     */
    public static string contactName;
    public static string contactBio;
    public static Sprite avatar;
    // Start is called before the first frame update
    void Start()
    {
        SetAvatarInfo();
        
    }

    
    public void SetAvatarInfo() {
        gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = avatar;
        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(contactName);
    }
}
