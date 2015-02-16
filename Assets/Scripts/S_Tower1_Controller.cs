using UnityEngine;
using System.Collections;

public class S_Tower1_Controller : MonoBehaviour {

	public GameObject TowerTop;
	public GameObject TowerBottom;

	public AudioSource DestroySound;

	public GameObject NextBlocks;
	public GameObject ThisTower1;
	public GameObject NextTower1;

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
	public bool BugFix = false; //Stops tower auto switching to tower 2 after switching back from tower 4.

	// Use this for initialization
	void Start () {
		TowerTop.renderer.material.color = Color.gray;
		TowerBottom.renderer.material.color = Color.gray;
		this.transform.localScale = new Vector3 (1.02f,1.02f,1.02f);
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
			Socket5.SendMessage("unSelected");
			Socket10.SendMessage("unSelected");
			print ("sent1");
			NextTower1.SendMessage ("Selected1");
			TowerTop.renderer.material.color = Color.white;
			TowerBottom.renderer.material.color = Color.white;
			this.transform.localScale = new Vector3 (1,1,1);
		}
	}

	void DestroyBlockCommand(){
		if (Input.GetKeyUp(KeyCode.LeftArrow) && ThisIsSelected == true){
			print ("sent1");
			Camera.main.SendMessage("TimePenaltySmall");
			DestroySound.Play();
			Socket5.SendMessage ("DestroyBlock");
			Socket10.SendMessage ("DestroyBlock");
		}
	}

	void Selected5(){
		BugFix = true;
		ThisIsSelected = true;
		Socket5.SendMessage("isSelected");
		Socket10.SendMessage("isSelected");
		NextBlocks.SendMessage("SelectedTower1");
		TowerTop.renderer.material.color = Color.gray;
		TowerBottom.renderer.material.color = Color.gray;
		this.transform.localScale = new Vector3 (1.02f,1.02f,1.02f);
	}

	//Colour Add for Socket 1 ... top
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
