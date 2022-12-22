using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    // toggle changed 
    public void toggle(bool muted){
        if (muted){
            //mute
            AudioListener.volume = 0;
        }
        else {
            // unmute
            AudioListener.volume = 1;
        }


    }
}
