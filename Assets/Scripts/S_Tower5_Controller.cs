﻿using UnityEngine;
using System.Collections;

public class S_Tower5_Controller : MonoBehaviour {

	public GameObject NextBlocks;
	public GameObject ThisTower5;
	public GameObject NextTower5;
	
	public GameObject Socket1;
	public GameObject Socket2;
	public GameObject Socket3;
	public GameObject Socket4;
	public GameObject Socket5;
	public GameObject Socket6;
	public GameObject Socket7;
	public GameObject Socket8;
	public GameObject Socket9;
	public GameObject Socket10;
	
	public bool ThisIsSelected = true;
	public bool BugFix = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SelectNextTower();
		DestroyBlockCommand();
		BugFix = false;
	}
	
	void SelectNextTower(){
		if (Input.GetKeyUp(KeyCode.Space) && ThisIsSelected == true && BugFix == false){
			ThisIsSelected = false;
			print ("sent5");
			NextTower5.SendMessage ("Selected5");
		}
	}
	
	void DestroyBlockCommand(){
		if (Input.GetKeyUp(KeyCode.LeftArrow) && ThisIsSelected == true){
			print ("sent5");
			Socket5.SendMessage ("DestroyBlock");
			Socket10.SendMessage ("DestroyBlock");
		}
	}
	
	void Selected4(){
		BugFix = true;
		ThisIsSelected = true;
		NextBlocks.SendMessage("SelectedTower5");
	}
	
	//Colour Add for Socket 1
	void AddRedBlock(){
		Socket1.SendMessage("AddRedBlock");
		print ("Tower RED");
	}
	void AddGreenBlock(){
		Socket1.SendMessage("AddGreenBlock");
		print ("Tower GREEN");
	}
	void AddBlueBlock(){
		Socket1.SendMessage("AddBlueBlock");
		print ("Tower BLUE");
	}
	void AddYellowBlock(){
		Socket1.SendMessage("AddYellowBlock");
		print ("Tower YELLOW");
	}

	//bottom
	void AddRedBlock2(){
		Socket6.SendMessage("AddRedBlock");
		print ("Tower RED");
	}
	void AddGreenBlock2(){
		Socket6.SendMessage("AddGreenBlock");
		print ("Tower GREEN");
	}
	void AddBlueBlock2(){
		Socket6.SendMessage("AddBlueBlock");
		print ("Tower BLUE");
	}
	void AddYellowBlock2(){
		Socket6.SendMessage("AddYellowBlock");
		print ("Tower YELLOW");
	}
}