using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float progress;
    public float sleep;
    public float sanity;
    public float time;



    public PlayerData(StatBars stats, Clock clock)
    {
        progress = stats.CurrentProgress;
        sleep = stats.CurrentSleep;
        sanity = stats.CurrentSanity;
        time = clock.timeStart;

    }

}
