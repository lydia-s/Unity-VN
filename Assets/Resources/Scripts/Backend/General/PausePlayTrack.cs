using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PausePlayTrack : MonoBehaviour
{
    public AudioSource audio;
    public Sprite pause;
    public Sprite play;
    public Image pauseplayButton;
    public void PlayTrack() {
        if (!audio.isPlaying)
        {
            audio.Play();
            pauseplayButton.overrideSprite = pause;
            
        }
        else {
            audio.Pause();
            pauseplayButton.overrideSprite = play;
        }
    }
    
}
