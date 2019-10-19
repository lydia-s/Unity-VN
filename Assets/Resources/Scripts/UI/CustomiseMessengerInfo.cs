using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 * CustomiseMessengerInfo customises the components of a messenger scene to a specific person
 */
public class CustomiseMessengerInfo : MonoBehaviour
{
    public static string contactName;
    public static string contactBio;
    public static Sprite avatar;
    public GameObject placeholderAvatar;
    public TextMeshProUGUI placeholderName;
    // Start is called before the first frame update
    void Start()
    {
        SetAvatarInfo(); 
    }
    
    public void SetAvatarInfo() {
        placeholderAvatar.GetComponent<Image>().sprite = avatar;
        placeholderName.text = contactName;
        //placeholderName.SetText(contactName);
    }
}
