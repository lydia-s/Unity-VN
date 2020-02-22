using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateMessage : MonoBehaviour
{
   // public TextMeshProUGUI inputText = null;
    public GameObject received;
    public GameObject sent;
    public GameObject placeMessage = null;
    public GameObject savePlace = null;//where the saveandupdatemessages script is attached
    public TextMeshProUGUI avatarName;
    float waitTime = 2f;
    public static bool posted = false;
    private void Start()
    {

    }
    IEnumerator WaitForReply(string message)
    {
        yield return new WaitForSecondsRealtime(1f);
        float betweenDotsTime = 0.3f;
        //yield return new WaitForSecondsRealtime(1.5f);
        GameObject ellipsis = CreateEllipsis();
        float wait = waitTime;
        while (wait>0) {
            ellipsis.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSecondsRealtime(betweenDotsTime);
            ellipsis.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ".";
            yield return new WaitForSecondsRealtime(betweenDotsTime);
            ellipsis.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "..";
            yield return new WaitForSecondsRealtime(betweenDotsTime);
            ellipsis.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "...";
            yield return new WaitForSecondsRealtime(betweenDotsTime);
            wait--;
        }

         yield return new WaitForSecondsRealtime(betweenDotsTime);
         DestroyEllipsis(ellipsis);
         GameObject msg = Instantiate(received) as GameObject;
         msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = message;
         msg.transform.SetParent(placeMessage.transform, false);
         msg.name = received.name;
         posted = true;
         yield return null;


    }
    public GameObject CreateEllipsis() {
        GameObject msg = Instantiate(received) as GameObject;
        msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "...";
        msg.transform.SetParent(placeMessage.transform, false);
        msg.name = received.name;
        return msg;
    }

    IEnumerator AnimateEllipsis(GameObject ellipsis) {
        string dots = ellipsis.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;

        Debug.Log(dots);
        if (ellipsis==null) {
                yield break;
            }

            if (dots.Length >= 3)
            {
                dots = "";
                ellipsis.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dots;
            }
            else
            {
                dots.Insert(0, ".");
                ellipsis.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dots;
            }

            yield return new WaitForSecondsRealtime(1f);
        

    }
    public void DestroyEllipsis(GameObject ellipsis) {
        Destroy(ellipsis);
    }

    //for loading new messages
    public void CreateMessage(string message, string messageType) {
        if (messageType == "Sent")
        {
            GameObject msg = Instantiate(sent) as GameObject;
            msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = message;
            msg.transform.SetParent(placeMessage.transform, false);
            msg.name = sent.name;
            posted = true;
        }
        else {
            StartCoroutine(WaitForReply(message));

        }
        
    }

    public void LoadOldMessages(string message, string messageType) {
        if (messageType == "Sent")
        {
            GameObject msg = Instantiate(sent) as GameObject;
            msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = message;
            msg.transform.SetParent(placeMessage.transform, false);
            msg.name = sent.name;
        }
        else
        {

            GameObject msg = Instantiate(received) as GameObject;
            msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = message;
            msg.transform.SetParent(placeMessage.transform, false);
            msg.name = received.name;

        }

    }

    //for loading old messages from files ***OLD used in SaveAndUpdateMessages***

    public void CreateMessage(GameObject messageBoxType, string message)
    {
        GameObject msg = Instantiate(messageBoxType) as GameObject;//instantiate message 
        msg.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = message;//set test
        msg.transform.SetParent(placeMessage.transform, false);//set parent
        msg.name = messageBoxType.name;
    }

}
