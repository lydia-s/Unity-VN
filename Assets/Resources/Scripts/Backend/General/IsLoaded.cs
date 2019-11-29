using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLoaded : MonoBehaviour
{

    public void SelectLoad() {
        StatBars.IsLoaded = true;
        Clock.IsLoaded = true;
    }
    public void Unload() {
        StatBars.IsLoaded = false;
        Clock.IsLoaded = false;
    }
}
