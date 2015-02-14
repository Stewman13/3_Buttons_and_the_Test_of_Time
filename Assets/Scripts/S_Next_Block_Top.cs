using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_Next_Block_Top : MonoBehaviour {

	public bool sending = false; //made to fix an annoying bug with colour sending!

	public GameObject TowerSelected;
	public GameObject CurrentColour;
	public GameObject NextColourBlock;

	public GameObject Tower1;
	public GameObject Tower2;
	public GameObject Tower3;
	public GameObject Tower4;
	public GameObject Tower5;

	public GameObject BlueBlock;
	public GameObject YellowBlock;
	public GameObject GreenBlock;
	public GameObject RedBlock;

	public float RandomNumber = 1;

	// Use this for initialization
	void Start () {
		RandomNumber = Random.Range(1,4);
		ColourCorrespond();

		if (RandomNumber == 1){
			CurrentColour = RedBlock;
		}
		if (RandomNumber == 2){
			CurrentColour = YellowBlock;
		}
		if (RandomNumber == 3){
			CurrentColour = BlueBlock;
		}
		if (RandomNumber == 4){
			CurrentColour = GreenBlock;
		}
		NextColourBlock = Instantiate(CurrentColour, transform.position, transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		SendColour();
		sending = false;
	}

	void ColourCorrespond(){
		if (RandomNumber == 1){
			CurrentColour = RedBlock;
		}
		if (RandomNumber == 2){
			CurrentColour = YellowBlock;
		}
		if (RandomNumber == 3){
			CurrentColour = BlueBlock;
		}
		if (RandomNumber == 4){
			CurrentColour = GreenBlock;
		}
	}


	//alot of this was writen Unnessasirily in my search to fix a bug. I havn't had time to shorten it yet.
	void SendColour(){
		if (Input.GetKeyUp(KeyCode.RightArrow) && CurrentColour == RedBlock && sending == false){
			sending = true;
			print ("sent Red!");
			TowerSelected.SendMessage ("AddRedBlock");
			Destroy (NextColourBlock);
			RandomizeNumbers();
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && CurrentColour == GreenBlock && sending == false){
			sending = true;
			print ("sent Green!");
			TowerSelected.SendMessage ("AddGreenBlock");
			Destroy (NextColourBlock);
			RandomizeNumbers();
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && CurrentColour == BlueBlock && sending == false){
			sending = true;
			print ("sent Blue!");
			TowerSelected.SendMessage ("AddBlueBlock");
			Destroy (NextColourBlock);
			RandomizeNumbers();
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && CurrentColour == YellowBlock && sending == false){
			sending = true;
			print ("sent Yellow!");
			TowerSelected.SendMessage ("AddYellowBlock");
			Destroy (NextColourBlock);
			RandomizeNumbers();
		}
	}
	
	void RandomizeNumbers(){
		RandomNumber = Random.Range(1,5);
		ColourCorrespond();
		print ("randomised, and assigned colour values");
		NewColour();
	}

	void NewColour(){
		NextColourBlock = Instantiate(CurrentColour, transform.position, transform.rotation) as GameObject;
		print ("added new colour to Next Block list");
	}


	void SelectedTower1(){
		TowerSelected = Tower1;
	}
	void SelectedTower2(){
		TowerSelected = Tower2;
	}
	void SelectedTower3(){
		TowerSelected = Tower3;
	}
	void SelectedTower4(){
		TowerSelected = Tower4;
	}
	void SelectedTower5(){
		TowerSelected = Tower5;
	}
}
