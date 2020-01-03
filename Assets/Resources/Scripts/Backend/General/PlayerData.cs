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
    public List<string> messageHistory1;//in the format: message | sent
    public List<string> messageHistory2;
    public List<string> messageHistory3;
    public Dictionary<string, string> storyPositions = new Dictionary<string, string>();
    public string playerName;


    public PlayerData(StatBars stats, Clock clock, MessageLists messageLists)
    {
        progress = stats.CurrentProgress;
        sleep = stats.CurrentSleep;
        sanity = stats.CurrentSanity;
        time = clock.timeStart;
        messageHistory1 = messageLists.messageHistory1;
        messageHistory2 = messageLists.messageHistory2;
        messageHistory3 = messageLists.messageHistory3;
        storyPositions = messageLists.storyPositions;
        

    }

}
