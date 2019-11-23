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


    }
    void UpdateProgress() {
        if (((CurrentProgress / MaxProgress) * 100)<=100)
        {
            string percent = "" + (CurrentProgress / MaxProgress) * 100 + "%";
            percentageProgress.text = percent;
        }
        
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
