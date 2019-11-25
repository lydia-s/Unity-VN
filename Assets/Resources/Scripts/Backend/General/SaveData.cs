using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public GameObject saveCode;
    public void SaveStats()
    {
        SaveSystem.SaveData(saveCode.GetComponent<StatBars>());
    }
}
