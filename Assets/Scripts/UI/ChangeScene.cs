using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChangeScene : MonoBehaviour
{


    public void LoadMessenger()
    {
        CustomiseMessengerInfo.contactName = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        CustomiseMessengerInfo.avatar = transform.GetChild(1).gameObject.GetComponent<Image>().sprite;
        //get list of message objects and populate list view content with them
        SceneManager.LoadScene("Messenger");
    }
    public void LoadContacts()
    {
        SceneManager.LoadScene("ContactsList");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
