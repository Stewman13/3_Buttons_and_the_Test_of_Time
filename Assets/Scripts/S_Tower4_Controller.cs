using UnityEngine;
using System.Collections;

public class S_Tower4_Controller : MonoBehaviour {

	public GameObject NextBlocks;
	public GameObject ThisTower4;
	public GameObject NextTower4;
	
	public GameObject Socket1;
	public GameObject Socket2;
	public GameObject Socket3;
	public GameObject Socket4;
	public GameObject Socket5;
	
	public bool ThisIsSelected = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SelectNextTower();
		DestroyBlockCommand();
	}
	
	void SelectNextTower(){
		if (Input.GetKeyUp(KeyCode.Space) && ThisIsSelected == true){
			ThisIsSelected = false;
			print ("sent4");
			NextTower4.SendMessage ("Selected4");
		}
	}
	
	void DestroyBlockCommand(){
		if (Input.GetKeyUp(KeyCode.LeftArrow) && ThisIsSelected == true){
			print ("sent4");
			Socket5.SendMessage ("DestroyBlock");
		}
	}
	
	void Selected3(){
		ThisIsSelected = true;
		NextBlocks.SendMessage("SelectedTower4");
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
}
