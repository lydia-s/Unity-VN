﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResizeTextBox : MonoBehaviour
{
    public TextMeshProUGUI text = null;
    public GameObject gOb = null;
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        var myHeight = text.preferredHeight;
        gOb.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, myHeight);


    }
}
