using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }
    public void PlayAnimation() {
        if (gameObject.GetComponent<Animator>().enabled == false) {
            gameObject.GetComponent<Animator>().enabled = true;
        }
        
    }
}
