using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 * CustomiseMessengerInfo customises the components of a messenger scene to a specific person
 */
public class CustomisePostInfo : MonoBehaviour
{
    public TextMeshProUGUI contactName;
    public Image avatar;
    public Image placeholderAvatar;
    public TextMeshProUGUI placeholderName;
    // Start is called before the first frame update
    void Start()
    {
        SetPostInfo(); 
    }


    public void SetPostInfo() {
        placeholderAvatar.sprite = avatar.sprite;
        placeholderName.text = contactName.text.ToString();
    }
}
