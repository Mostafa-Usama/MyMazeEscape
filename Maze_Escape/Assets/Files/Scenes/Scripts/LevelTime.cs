using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelTime : MonoBehaviour
{
    public Text txt;
    public float timee,ti=0;
    void Start()
    {

    }

    void Update()
    {
        // calculate time since start button is pressed

        timee = (int)Time.timeSinceLevelLoad - ti;
        txt.text = "Time: "+timee.ToString(); 
    }
    // called when start button is pressed
    
}
