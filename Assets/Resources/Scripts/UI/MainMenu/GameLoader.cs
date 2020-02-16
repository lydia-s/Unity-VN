using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressTxt;
    public GameObject cueCards;
    public void LoadLevel(int sceneIndex) {
        StartCoroutine(LoadAsync(sceneIndex));
        
    }
    IEnumerator LoadAsync(int sceneIndex) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        cueCards.SetActive(false);
        loadingScreen.SetActive(true);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;
            progressTxt.text = (progress * 100f) + "%";
            yield return null;//wait until next frame before continuing
        }
        loadingScreen.SetActive(false);
    }
}
