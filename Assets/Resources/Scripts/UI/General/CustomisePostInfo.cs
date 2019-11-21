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
    
    public Image placeholderAvatar;
    public TextMeshProUGUI placeholderName;
    // Start is called before the first frame update
    void Start()
    {
        SetPostInfo(); 
    }


    public void SetPostInfo() {
        TextMeshProUGUI contactName = GameObject.Find("Avatar").transform.Find("Avatar name").GetComponent<TextMeshProUGUI>();
        Image avatar = GameObject.Find("Avatar").GetComponent<Image>();
        placeholderAvatar.sprite = avatar.sprite;
        placeholderName.text = contactName.text.ToString();
    }
}
