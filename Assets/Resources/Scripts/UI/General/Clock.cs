using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Clock : MonoBehaviour
{
    public float timeStart = 1020;
    public TextMeshProUGUI clock;
    public static bool IsLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
        clock.text = timeStart.ToString();
        if (IsLoaded == true) {
            PlayerData data = SaveSystem.LoadData();
            timeStart = data.time;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timeStart += Time.deltaTime*0.3f;
        string seconds = Mathf.Floor(timeStart%60).ToString("00");//actually minutes in our universe
        string minutes = Mathf.Floor(timeStart / 60).ToString("00");//actually hours in our universe
        clock.text = minutes + " : " + seconds;
        if (Int32.Parse(minutes) == 24) {
            timeStart = 0;
        }


    }
}
