using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RadialMenu : MonoBehaviour
{
    public TextMeshProUGUI label;
    public RadialButton buttonPrefab;
    public RadialButton selected;
    StatBars statsBars;
    Clock clock;
    public GameObject actionObj;
    void Start() {
        statsBars = GameObject.Find("StatsBars").GetComponent<StatBars>();
        clock = GameObject.Find("WorldClock").GetComponent<Clock>();
    }
    // Start is called before the first frame update
    public void SpawnButtons(Interactable obj)
    {
        StartCoroutine(AnimateButtons(obj));
        
    }
    IEnumerator AnimateButtons (Interactable obj) {
        for (int i = 0; i < obj.options.Length; i++)
        {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);
            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector2(xPos, yPos) * 100f;
            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;
            newButton.Anim();
            yield return new WaitForSeconds(0.06f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            if (selected) {
                //do action when button selected
                PerformAction(selected.title);
            }
            Destroy(gameObject); 
        }
    }
    void PerformAnimation(string action) {
        var x = Instantiate(actionObj, new Vector2(-200, 0), Quaternion.identity);
        x.transform.SetParent(GameObject.Find("Panel").transform, false);
        x.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/"+action);
        x.name = action;
        Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
    void PerformAction(string action) {
        //play animation after each action
        action = action.ToLower();
        switch (action) {
            case "sleep":
                //perhaps it returns you to fully rested state
                statsBars.IncreaseSleep(1.0f);
                statsBars.ReduceSpirit(2.0f);
                clock.timeStart += 60f;
                PerformAnimation(action);
                break;
            case "nap":
                statsBars.IncreaseSleep(0.5f);
                statsBars.IncreaseSpirit(2.0f);
                clock.timeStart += 30f;
                PerformAnimation(action);
                break;
            case "work":
                statsBars.IncreaseProgress(0.5f);
                statsBars.ReduceSleep(2.0f);
                statsBars.ReduceSanity(1.5f);
                clock.timeStart += 60f;
                PerformAnimation(action);
                break;
            case "research":
                statsBars.ReduceSanity(0.5f);
                statsBars.ReduceSleep(0.5f);
                clock.timeStart += 30f;
                PerformAnimation(action);
                break;
            case "study":
                statsBars.ReduceSanity(0.5f);
                statsBars.ReduceSleep(0.5f);
                clock.timeStart += 30f;
                PerformAnimation(action);
                break;
            case "read":
                statsBars.ReduceSanity(0.5f);
                statsBars.ReduceSleep(0.5f);
                clock.timeStart += 30f;
                PerformAnimation(action);
                break;
            case "play games":
                statsBars.IncreaseSanity(1.0f);
                statsBars.ReduceSleep(0.5f);
                clock.timeStart += 60f;
                PerformAnimation(action);
                break;
            case "submit":
                if (statsBars.CurrentProgress == 20f)
                {
                    SceneManager.LoadScene("Submit");
                }
                else {
                    Debug.Log("YOU CANNOT SUBMIT!");
                }
                break;
            default:
                break;
        }
    }
}
