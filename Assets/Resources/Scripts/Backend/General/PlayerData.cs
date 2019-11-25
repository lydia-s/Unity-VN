using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float progress;
    public float sleep;
    public float sanity;



    public PlayerData(StatBars stats)
    {
        progress = stats.CurrentProgress;
        sleep = stats.CurrentSleep;
        sanity = stats.CurrentSanity;


    }

}
