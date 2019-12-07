using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLoaded : MonoBehaviour
{
    /*
     * If you load a game it sets the IsLoaded variable to true
     * there are checks for this in the methods' on start
     * so if the option to load a previous game has been selected
     * it will load in all the old data
     */
    public void SelectLoad() {
        StatBars.IsLoaded = true;
        Clock.IsLoaded = true;
        MessageLists.IsLoaded = true;
    }
    /*
     * Unload sets the IsLoaded variables to false when you load out of a game
     * If you want to play a new game the next time you don't want to load back in your old data
     */
    public void Unload() {
        StatBars.IsLoaded = false;
        Clock.IsLoaded = false;
        MessageLists.IsLoaded = false;
    }
}
