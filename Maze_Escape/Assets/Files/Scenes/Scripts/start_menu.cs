using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_menu : MonoBehaviour
{
    // Start is called before the first frame update
   public void quit(){
    // quit game (doesn't work in the editor)
    Application.Quit();
   }

    public void Startlevel()
    {
        // load first level
        SceneManager.LoadScene(1);
    }
}
