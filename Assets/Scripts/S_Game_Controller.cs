using UnityEngine;
using System.Collections;

public class S_Game_Controller : MonoBehaviour {

	public AudioSource GameOverAudio;
	public bool Over = false;
	public int playOnce = 0;

	public TextMesh GameOverScore;
	public TextMesh GameOverText;
	public TextMesh GameOverRetry;

	public TextMesh TimeDisplay;
	public float timer;
	public string timerFormatted;
	public string niceTime;
	public bool isTickingQuicker = false;

	public TextMesh ScoreDisplay;
	public float TotalScore;
	public string scoreFormat;
	public bool ScoreDisplayisHere = true;

	// Use this for initialization
	void Start () {

	}
	
	void Update(){
		TickingTimer();
		TimerDisplayer();
		RunScoreDisplay();

		if(Over == true && playOnce == 0){
			playOnce++;
			GameOverAudio.Play();
		}
	}

	void TimerDisplayer(){
		int minutes = Mathf.FloorToInt(timer / 60F);
		int seconds = Mathf.FloorToInt(timer - minutes * 60);
		
		string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
		TimeDisplay.text = niceTime;
	}

	void TickingTimer(){
		timer -= 1.0f * Time.deltaTime;

		if(timer <= 0.0f){
			timer = 0;

			Screen.lockCursor = false;
			Time.timeScale = 0;
			ScoreDisplayisHere = false;
			GameOverText.text = ("GAME OVER");
			Over = true;
			Destroy(ScoreDisplay);
			GameOverRetry.text = ("Esc To Retry");

			if(Input.GetKeyUp (KeyCode.Escape)){
				Application.LoadLevel(Application.loadedLevel);
			}

		//	StartCoroutine(GameOver(3.0f));
			print("GameOver!");
		}
	}

	/*
	IEnumerator GameOver(float waitTime) {
		Screen.lockCursor = false;
		Time.timeScale = 0;
		ScoreDisplayisHere = false;
		GameOverText.text = ("GAME OVER");
		Destroy(ScoreDisplay);

		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel(0);
	}
*/
	void TickQuickerON(){
		isTickingQuicker = true;
	}
	void TickQuickerOFF(){
		isTickingQuicker = false;
	}
	void TimePenaltySmall(){
		timer -= 3.0f;
	}
	void TimePenaltyLarge(){
		timer -= 7.0f;
	}
	void TimeBonus(){
		timer += 2.0f;
	}
	void BurnTime(){
		timer -= 1.0f * Time.deltaTime;
	}

	void RunScoreDisplay(){
		int points = Mathf.FloorToInt(TotalScore);

		string scoreFormat = string.Format("{000000}", points);
		if(ScoreDisplayisHere == true){
			ScoreDisplay.text = scoreFormat;
		}
		if(ScoreDisplayisHere == false){
			GameOverScore.text = scoreFormat;
		}
	}
	void Add10Points(){
		TotalScore += 10;
	}
	void Add20Points(){
		TotalScore += 20;
	}
}
