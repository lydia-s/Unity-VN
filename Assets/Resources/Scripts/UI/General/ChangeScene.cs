using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public void LoadGameMenu()
    {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("PauseMenu");
        Time.timeScale = 0f;

    }

    public void ResumeGame() {
        string scene = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
    public void LoadContacts()
    {
        SceneManager.LoadScene("ContactsList");
       
    }
    public void LoadRoom() {
        SceneManager.LoadScene("Room");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void LoadProfilePage()
    {
        SceneManager.LoadScene("Profile");
      
    }
    public void Quit()
    {
        Application.Quit();
    }
}
