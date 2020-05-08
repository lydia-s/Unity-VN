using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Clock : MonoBehaviour
{
    public float timeStart = 1020;
    public TextMeshProUGUI clock;
    public TextMeshProUGUI dayName;
    public static bool IsLoaded = false;
    public Dictionary<int, string> weekDays = new Dictionary<int, string> { { 0, "Friday" }, { 1, "Saturday" }, { 2, "Sunday" }, { 3, "Monday" }, };
    public int dayNum = 0;
    StatBars statsBars;
    public static int timeSinceLastChoice = 0;
    // Start is called before the first frame update
    void Start()
    {
        statsBars = GameObject.Find("StatsBars").GetComponent<StatBars>();
        if (IsLoaded == true) {
            PlayerData data = SaveSystem.LoadData();
            timeStart = data.time;
            dayNum = data.dayNum;
        }
        dayName.text = weekDays[dayNum];
        clock.text = timeStart.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        string seconds1="";
        timeStart += Time.deltaTime*0.3f;
        string seconds = Mathf.Floor(timeStart%60).ToString("00");//actually minutes in our universe
        string minutes = Mathf.Floor(timeStart / 60).ToString("00");//actually hours in our universe
        clock.text = minutes + " : " + seconds;
        if (seconds1 != seconds) {
            statsBars.ReduceSleep(0.0005f);
            statsBars.ReduceSpirit(0.0005f);
        }

        seconds1 = seconds;
        if (Int32.Parse(minutes) == 24) {
            timeStart = 0;
            /*
             * Change day of the week
             */
            dayNum++;
            if (dayNum<3) {
                dayName.text = weekDays[dayNum];
            }
        }


    }
}
