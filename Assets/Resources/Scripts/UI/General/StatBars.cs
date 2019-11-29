using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StatBars : MonoBehaviour
{
    public float CurrentSleep { get; set; }
    public float MaxSleep { get; set; }
    public float CurrentSanity { get; set; }
    public float MaxSanity { get; set; }
    public float CurrentProgress { get; set; }
    public float MaxProgress { get; set; }
    public Slider sleepBar;
    public Slider sanityBar;
    public Slider submissionBar;
    public TextMeshProUGUI percentageProgress;
    public static bool IsLoaded = false;
    
   
    // Start is called before the first frame update
    void Start()
    {

        MaxSleep = 20f;
        CurrentSleep = MaxSleep;
        MaxSanity = 20f;
        CurrentSanity = MaxSanity;
        MaxProgress = 20f;
        CurrentProgress = 0f;
        sleepBar.value = CurrentSleep/MaxSleep;
        sanityBar.value = CurrentSanity/MaxSanity;
        submissionBar.value = CurrentProgress;
        if (IsLoaded == true) {
            PlayerData data = SaveSystem.LoadData();
            CurrentSleep = data.sleep;
            CurrentSanity = data.sanity;
            CurrentProgress = data.progress;
        }
       


    }
    void UpdateProgress() {
        if (((CurrentProgress / MaxProgress) * 100)<=100)
        {
            string percent = "" + (CurrentProgress / MaxProgress) * 100 + "%";
            percentageProgress.text = percent;
        }
        sanityBar.value = CurrentSanity / MaxSanity;
        sleepBar.value = CurrentSleep / MaxSleep;
        submissionBar.value = CurrentProgress / MaxProgress;
    }
    void ReduceSanity(float sanityValue) {
        CurrentSanity -= sanityValue;
        sanityBar.value = CurrentSanity / MaxSanity;
    }
    void ReduceSleep(float tiredValue)
    {
        CurrentSleep -= tiredValue;
        sleepBar.value = CurrentSleep / MaxSleep;

    }
    void IncreaseProgress(float progress)
    {
        CurrentProgress += progress;
        submissionBar.value =CurrentProgress/MaxProgress;

    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateProgress();
        if (Input.GetKeyDown("space"))
        {
            ReduceSleep(1f);
            ReduceSanity(1f);
            IncreaseProgress(1f);
        }



    }
}
