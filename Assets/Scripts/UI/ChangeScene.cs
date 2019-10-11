using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChangeScene : MonoBehaviour
{


    public void LoadMessenger() {
        SetMessenger.contactName = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        SetMessenger.avatar = transform.GetChild(1).gameObject.GetComponent<Image>().sprite;
        SceneManager.LoadScene("Messenger");
    }
    public void LoadContacts()
    {
        SceneManager.LoadScene("ContactsList");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
