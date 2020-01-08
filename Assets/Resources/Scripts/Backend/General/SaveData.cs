using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    /*
     * SaveData calls the method SaveData in Savesystem which saves the data using binary formatter
     */
    public GameObject statsBars;
    public GameObject timeSave;
    public static bool gameWasJustSaved = false;
    /*
     * SaveStats is called on the save button
     */
    public void SaveStats()
    {
        GameObject gameOb = GameObject.Find("WorldClock");
        SaveSystem.SaveData(statsBars.GetComponent<StatBars>(), timeSave.GetComponent<Clock>(), gameOb.GetComponent<MessageLists>());
        gameWasJustSaved = true;

    }


}
