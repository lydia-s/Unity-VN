using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StatBars : MonoBehaviour
{
    /*
     * StatsBars manages the in game progress metres and loads any previously saved data on start
     */
    public float CurrentSleep { get; set; }
    public float MaxSleep { get; set; }
    public float CurrentSpirit { get; set; }
    public float MaxSpirit { get; set; }
    public float CurrentSanity { get; set; }
    public float MaxSanity { get; set; }
    public float CurrentProgress { get; set; }
    public float MaxProgress { get; set; }
    public Slider sleepBar;
    public Slider sanityBar;
    public Slider teamSpiritBar;
    public Slider submissionBar;
    public TextMeshProUGUI percentageProgress;
    public static bool IsLoaded = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
        CurrentSpirit = 10f;
        MaxSpirit = 20f;
        MaxSleep = 20f;
        CurrentSleep = 10f;
        MaxSanity = 20f;
        CurrentSanity = MaxSanity;
        MaxProgress = 20f;
        CurrentProgress = 0f;
        sleepBar.value = CurrentSleep/MaxSleep;
        sanityBar.value = CurrentSanity/MaxSanity;
        teamSpiritBar.value = CurrentSpirit / MaxSpirit;
        submissionBar.value = CurrentProgress;
        if (IsLoaded == true) {
            PlayerData data = SaveSystem.LoadData();
            CurrentSleep = data.sleep;
            CurrentSanity = data.sanity;
            CurrentSpirit = data.spirit;
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
        teamSpiritBar.value = CurrentSpirit / MaxSpirit;
    }
    public void ReduceSanity(float sanityValue) {
        if (CurrentSanity>0f) {
            CurrentSanity -= sanityValue;
            sanityBar.value = CurrentSanity / MaxSanity;
        }
        
    }
    public void ReduceSleep(float tiredValue)
    {
        if (CurrentSleep>0f) {
            CurrentSleep -= tiredValue;
            sleepBar.value = CurrentSleep / MaxSleep;
        }
    }
    public void ReduceSpirit(float spiritValue)
    {
        if (CurrentSpirit > 0f)
        {
            CurrentSpirit -= spiritValue;
            teamSpiritBar.value = CurrentSpirit / MaxSpirit;
        }
    }
    public void IncreaseSpirit(float spiritValue)
    {
        CurrentSpirit += spiritValue;
        teamSpiritBar.value = CurrentSpirit / MaxSpirit;
        
    }
    public void IncreaseSleep(float sleepValue)
    {
        CurrentSleep += sleepValue;
        sleepBar.value = CurrentSleep / MaxSleep;

    }
    public void IncreaseSanity(float sanityValue)
    {
        CurrentSanity += sanityValue;
        sanityBar.value = CurrentSanity / MaxSanity;
    }
    public void IncreaseProgress(float progress)
    {
        CurrentProgress += progress;
        submissionBar.value =CurrentProgress/MaxProgress;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgress();
    }
}
