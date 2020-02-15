using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelevantOrIrrelevant : MonoBehaviour
{
    public static bool relevant = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhatButtonWasPressed() {
        if (this.gameObject.name == "Relevant") {
            relevant = true;
        }
        else
        {
            relevant = false;
        }
    }
}
