using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {
	
	public GameObject panel; // Complete game Panel
	public AudioClip CoinSound = null; // Coin Sound
	private Rigidbody rb = null; // Rigid body
	private AudioSource ad = null; // play coin sound
	public Text txt; // coin score
	public LevelTime timeText; // access LevelTime script  
	float leveltime1=0,leveltime2=0,leveltime3=0; // time for level 1,2 and 3
	float time=0; // total time played
	int score = 0; // level score
	int level1=0,level2=0,level3=0; // score stored to calcualte high score 
	int totalScore = 0; // total score
	int index; // scene index
	bool hint = false;
	public GameObject NotEnough;
	public GameObject arrowHint;
	public Text yourScore,yourTime;
	void Start () {

		rb = GetComponent<Rigidbody> ();
		ad = GetComponent<AudioSource> ();
		index = SceneManager.GetActiveScene().buildIndex; // get current scene index
		timeText = GameObject.FindWithTag("time").GetComponent<LevelTime>(); // access Leveltime Script on time text
			
		}

	void Update () {
		// movement
			if (Input.GetButton ("Horizontal")) {
				rb.AddTorque(Vector3.back * Input.GetAxis("Horizontal")*10);
			}
			if (Input.GetButton ("Vertical")) {
				rb.AddTorque(Vector3.right * Input.GetAxis("Vertical")*10);
			}
			
		}
		
	

	void OnCollisionEnter(Collision coll){
		// finished level 1
		 if (coll.gameObject.tag.Equals ("Flag1")){
			level1 = score;
			// store score of level 1
			PlayerPrefs.SetInt("level1",level1);

			leveltime1 = timeText.timee;
			// store time of level 1
			PlayerPrefs.SetFloat("time1",leveltime1);
			// load next scene (level)
			SceneManager.LoadScene(++index);
		}
		// finished level 2
		if (coll.gameObject.tag.Equals ("Flag2")){
			level2 = score;
			// store score of level 2
			PlayerPrefs.SetInt("level2",level2);
			leveltime2 = timeText.timee;
			// store time of level 2
			PlayerPrefs.SetFloat("time2",leveltime2);
			// load next scene (level)
			SceneManager.LoadScene(++index);
		}
		// finished level 3
		if (coll.gameObject.tag.Equals ("Complete")){

			level3 = score;
			// store score of level 3
			PlayerPrefs.SetInt("level3",level3);

			leveltime3 = timeText.timee;
			// store time of level 3
			PlayerPrefs.SetFloat("time3",leveltime3);
			// calcualte total score of 3 levels
			totalScore = (PlayerPrefs.GetInt("level1")+(PlayerPrefs.GetInt("level2"))+(PlayerPrefs.GetInt("level3"))); 
			// compare current highscore with your total score 
			PlayerPrefs.SetInt("maxScore",Mathf.Max(PlayerPrefs.GetInt("maxScore"),totalScore));
			// calculate total time played of 3 levels 
			time =  (PlayerPrefs.GetFloat("time1")+(PlayerPrefs.GetFloat("time2"))+(PlayerPrefs.GetFloat("time3")));
			// compare current best time with your total time
			PlayerPrefs.SetFloat("leastTime",Mathf.Min(PlayerPrefs.GetFloat("leastTime"),time));
			// game complete panel active
			panel.SetActive(true);
			// show total score
			yourScore.text = "Score: " + totalScore;
			//show total time
			yourTime.text = "Time: " + time;
			// stop time
			Time.timeScale = 0;
			
		}
	}

	

	void OnTriggerEnter(Collider other) {
		// collects coin
		if (other.gameObject.tag.Equals ("Coin")) {
			// plays sound
			ad.PlayOneShot(CoinSound);
			// increase score
			score++;
			// set score text to new score
			txt.text = "Score: " + score;
			// destroy coin
			Destroy(other.gameObject);
		}
	}
	// hint button
	public void setHint(){
		// enough coins and hint not activated
		if (score >= 2 && !hint){
			// decrease score
			score-=2;
			// set score text to new score
			txt.text = "Score: " + score;
			// activate hint
	       	arrowHint.SetActive(true);
			hint = true;
		}
		else {	
			// not enough coins
			if (!hint){
				// show text saying not enough coins for 5 seconds
				NotEnough.SetActive(true);
				StartCoroutine(not_enough());
			}
		}

    }

	IEnumerator not_enough(){
		yield return new WaitForSeconds(5);
		NotEnough.SetActive(false);
	}
}
