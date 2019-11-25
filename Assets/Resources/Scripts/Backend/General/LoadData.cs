using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadPrevious
{

    public static PlayerData ReturnData() {
        PlayerData data = SaveSystem.LoadData();
        return data;
    }


    
}
