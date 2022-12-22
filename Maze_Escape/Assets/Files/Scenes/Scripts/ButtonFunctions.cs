using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject sound;

    private void Start()
    {

    }
    public void load()
    {
        // go back to normal game speed
        Time.timeScale = 1;
        // back to main menu
        SceneManager.LoadScene(0);
        
    }
   
}
