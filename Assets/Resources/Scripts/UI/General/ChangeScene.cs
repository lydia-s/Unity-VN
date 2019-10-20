using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChangeScene : MonoBehaviour
{



    public void LoadContacts()
    {
        SceneManager.LoadScene("ContactsList");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadProfilePage() {
        SceneManager.LoadScene("Profile");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
