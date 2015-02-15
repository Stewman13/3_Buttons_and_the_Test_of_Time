using UnityEngine;
using System.Collections;

public class S_Game_Controller : MonoBehaviour {

	public TextMesh TimeDisplay;
	public float timer;
	public string timerFormatted;
	public string niceTime;
	public bool isTickingQuicker = false;

	public TextMesh ScoreDisplay;
	public float TotalScore;
	public string scoreFormat;

	// Use this for initialization
	void Start () {

	}
	
	void Update(){
		TickingTimer();
		TimerDisplayer();
		RunScoreDisplay();
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
			print("GameOver!");
		}
	}

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
		ScoreDisplay.text = scoreFormat;
	}
	void Add10Points(){
		TotalScore += 10;
	}
	void Add20Points(){
		TotalScore += 20;
	}
}
