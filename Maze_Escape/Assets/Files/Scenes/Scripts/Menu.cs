using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu : MonoBehaviour
{
    public bool paused = false;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // pause if escape is pressed in the middle of the game anda the game is not paused
        if (Input.GetKeyDown(KeyCode.Escape) && !paused){
            // stop time (pause)
            Time.timeScale = 0;
            // pause menu active
            panel.SetActive(true);
            paused = true;
        }
        // unpause if escape is pressed in the middle of the game anda the game is paused
        else if (Input.GetKeyDown(KeyCode.Escape) && paused){
           // resume time(unpause)
            Time.timeScale = 1;
            // pause menue not acative
            panel.SetActive(false);
            paused = false;
        }
    }
    public void resume(){
   
    // resume pressed
    Time.timeScale = 1;
    panel.SetActive(false);
    paused = false;
   }
}
