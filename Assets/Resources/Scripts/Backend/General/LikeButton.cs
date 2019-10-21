using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeButton : MonoBehaviour
{
    public Image heart;
    static bool hearted = false;


    private void Start()
    {
        if (hearted == true) {
            heart.color = Color.red;
        }
    }
    public void HeartThis() {
        if (hearted == false)
        {
            hearted = true;
            heart.color = Color.red;
        }
        else {
            hearted = false;
            heart.color = Color.grey;
            Color col = heart.color;
            col.a = 0.40f;
            heart.color = col;
        }
    }


}
