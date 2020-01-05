using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public GameObject saveAnim;
    public void LoadGameMenu()
    {
        //PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("PauseMenu");
        Time.timeScale = 0f;

    }


    void SaveAnimation()
    {
        GameObject x = Instantiate(saveAnim, new Vector2(842, -477), Quaternion.identity);
        x.transform.SetParent(GameObject.Find("Panel").transform, false);
        x.name = "Saved";
        Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    public void ResumeGame() {
        //string scene = PlayerPrefs.GetString("lastLoadedScene");
        //SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
        if (SaveData.gameWasJustSaved)
        {
            SaveAnimation();
            SaveData.gameWasJustSaved = false;
        }
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
