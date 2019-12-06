using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public GameObject statsBars;
    public GameObject timeSave;
    public void SaveStats()
    {
        GameObject gameOb = GameObject.Find("WorldClock");
        SaveSystem.SaveData(statsBars.GetComponent<StatBars>(), timeSave.GetComponent<Clock>(), gameOb.GetComponent<MessageLists>());
    }
}
