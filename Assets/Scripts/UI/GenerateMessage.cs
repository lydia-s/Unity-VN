using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateMessage : MonoBehaviour
{
    public TextMeshProUGUI inputText = null;
    public GameObject messageBox = null;
    public GameObject replyBox = null;
    public GameObject placeMessage = null;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateMessage() {
       
        GameObject msg = Instantiate(messageBox) as GameObject;
        msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(inputText.text);
        msg.transform.SetParent(placeMessage.transform, false);
        
    }
    public void CreateReply() {
        GameObject msg = Instantiate(replyBox) as GameObject;
        msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(inputText.text);
        msg.transform.SetParent(placeMessage.transform, false);
    }
}
