using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text highScore;
    int score;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        // get stored highscore
       score = PlayerPrefs.GetInt("maxScore");
       // get stored best time
       time = PlayerPrefs.GetFloat("leastTime");
    }

    // Update is called once per frame
    void Update()
    {
        // update text with highscore and best time 
        highScore.text = "Highscore: "+ score + " Conis \n \n";
        highScore.text+= "Best Time: "+ time + " Seconds";
    }
}
