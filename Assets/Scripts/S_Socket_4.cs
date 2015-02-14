﻿using UnityEngine;
using System.Collections;

public class S_Socket_4 : MonoBehaviour {

	
	public bool SameColourAbove = false;
	public bool SameColourUnder = false;
	public bool Empty = true;

	public float BlockGapDistance  = 2;
	
	public GameObject Socket1;
	public GameObject Socket2;
	public GameObject Socket3;
	public GameObject Socket4;
	public GameObject Socket5;
	
	public GameObject EmptySocketBlock;
	public GameObject BlueBlock;
	public GameObject YellowBlock;
	public GameObject GreenBlock;
	public GameObject RedBlock;
	
	public GameObject BlockInPlace;
	public GameObject BlockInSocket;
	
	// Use this for initialization
	void Start () {
		BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		EmptySocket();
		RayCasts();
		BlockPopper();
	}
	
	void EmptySocket(){
		if (BlockInSocket == EmptySocketBlock){
			Empty = true;
			Socket5.SendMessage ("Emptying");
		}
		else if (BlockInSocket != EmptySocketBlock){
			Empty = false;
		}
	}

	void RayCasts(){
		RaycastHit HitDown;
		RaycastHit HitUp;
		
		Ray ColourCheckerUp = new Ray(transform.position, Vector3.up);
		Ray ColourCheckerDown = new Ray(transform.position, Vector3.down);
		
		Debug.DrawRay(transform.position, Vector3.up * BlockGapDistance);
		Debug.DrawRay(transform.position, Vector3.down * BlockGapDistance);

		if(!Empty){
			if(Physics.Raycast(ColourCheckerDown, out HitDown, BlockGapDistance)){ 
				if(HitDown.collider.tag == "Red_Box"  && BlockInSocket == RedBlock){
					SameColourUnder = true;
				}
				if(HitDown.collider.tag == "Blue_Box"  && BlockInSocket == BlueBlock){
					SameColourUnder = true;
				}
				if(HitDown.collider.tag == "Green_Box"  && BlockInSocket == GreenBlock){
					SameColourUnder = true;
				}
				if(HitDown.collider.tag == "Yellow_Box"  && BlockInSocket == YellowBlock){
					SameColourUnder = true;
				}
				if(HitDown.collider.tag == "Empty_Socket"){
					SameColourUnder = false;
				}
			}
			if(Physics.Raycast(ColourCheckerUp, out HitUp, BlockGapDistance)){ 
				if(HitUp.collider.tag == "Red_Box"  && BlockInSocket == RedBlock){
					SameColourAbove = true;
				}
				if(HitUp.collider.tag == "Blue_Box"  && BlockInSocket == BlueBlock){
					SameColourAbove = true;
				}
				if(HitUp.collider.tag == "Green_Box"  && BlockInSocket == GreenBlock){
					SameColourAbove = true;
				}
				if(HitUp.collider.tag == "Yellow_Box"  && BlockInSocket == YellowBlock){
					SameColourAbove = true;
				}
				if(HitUp.collider.tag == "Empty_Socket"){
					SameColourAbove = false;
				}
			}
		}
	}

	void BlockPopper(){
		if(SameColourAbove == true && SameColourUnder == true && Empty == false){
			PopVrtcl();
		}
	}
	
	
	//Set of 'add block' Recivers
	void AddRedBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = RedBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false){
			Socket5.SendMessage ("AddRedBlock");
		}
	}
	void AddBlueBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = BlueBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false){
			Socket5.SendMessage ("AddBlueBlock");
		}
	}
	void AddGreenBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = GreenBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false){
			Socket5.SendMessage ("AddGreenBlock");
		}
	}
	void AddYellowBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = YellowBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false){
			Socket5.SendMessage ("AddYellowBlock");
		}
	}
	//End of Recivers	

	void DestroyBlock (){
		if (Empty == false){
			Destroy (BlockInPlace);
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		else if (Empty == true){
			Socket3.SendMessage ("DestroyBlock");
		}
	}

	void PopVrtcl(){
		Destroy (BlockInPlace);
		SameColourUnder = false;
		SameColourAbove = false;
		//Add 20 points!!!!!!!!!!!!!!!!!!!
		BlockInSocket = EmptySocketBlock;
		BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		Socket3.SendMessage("BeingPoppedVrtcl"); 
		Socket5.SendMessage("BeingPoppedVrtcl"); 
	}

	void BeingPoppedVrtcl(){
		Destroy (BlockInPlace);
		SameColourUnder = false;
		SameColourAbove = false;
		//Add 20 points!!
		BlockInSocket = EmptySocketBlock;
		BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
	}

	void Emptying(){
		if (Empty == false && BlockInSocket == RedBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			Socket3.SendMessage ("AddRedBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false && BlockInSocket == BlueBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			Socket3.SendMessage ("AddBlueBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false && BlockInSocket == GreenBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			Socket3.SendMessage ("AddGreenBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false && BlockInSocket == YellowBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			Socket3.SendMessage ("AddYellowBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
	}
}
