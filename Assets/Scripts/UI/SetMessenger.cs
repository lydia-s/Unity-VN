using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetMessenger : MonoBehaviour
{
    public static string contactName = "Placeholder name";
    public static string contactBio = "Placeholder bio";
    public static Sprite avatar;
    // Start is called before the first frame update
    void Start()
    {
        SetAvatarInfo();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAvatarInfo() {
        this.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = avatar;
        this.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(contactName);
    }
}
