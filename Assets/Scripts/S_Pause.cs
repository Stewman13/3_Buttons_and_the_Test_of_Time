using UnityEngine;
using System.Collections;

public class S_Pause : MonoBehaviour {

	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeight = 170;
	bool paused = false;
	
	void Start ()
	{
		Screen.lockCursor = true;
		Time.timeScale = 1;
	}
	
	void OnGUI()
	{
		if(paused)
		{
			GUI.BeginGroup(new Rect(((Screen.width/2) - (groupWidth/2)),((Screen.height/2) - (groupHeight/2)), groupWidth, groupHeight));
			if(GUI.Button (new Rect(0,0,buttonWidth, buttonHeight),"Main Menu"))
			{
				Application.LoadLevel(0);
			}
			if(GUI.Button (new Rect(0,60,buttonWidth,buttonHeight),"Resume Game"))
			{
				paused = togglePause();
			}
			if(GUI.Button (new Rect(0,120,buttonWidth,buttonHeight),"Quit Game"))
			{
				Application.Quit();
			}
			GUI.EndGroup();
		}
	}
	
	void Update ()
	{
		if(Input.GetKeyUp (KeyCode.Escape))
			paused = togglePause();
	}
	
	bool togglePause()
	{
		if(Time.timeScale == 0)
		{
			Screen.lockCursor = true;
			Time.timeScale = 1;
			return(false);
		}
		else
		{
			Screen.lockCursor = false;
			Time.timeScale = 0;
			return(true);
		}
	}
}

//This script was copied from a help forum, I only changed small parts to suit my game.