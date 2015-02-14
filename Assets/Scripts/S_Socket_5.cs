using UnityEngine;
using System.Collections;

public class S_Socket_5 : MonoBehaviour {

	
	public bool SameColourAbove = false;
	public bool SameColourUnder = false;
	public bool Empty = true;
	
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
	}
	
	void EmptySocket(){
		if (BlockInSocket == EmptySocketBlock){
			Empty = true;
		}
		else if (BlockInSocket != EmptySocketBlock){
			Empty = false;
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
			//!!!
		}
	}
	void AddBlueBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = BlueBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false){
			//!!!
		}
	}
	void AddGreenBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = GreenBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false){
			//!!!
		}
	}
	void AddYellowBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = YellowBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false){
			//!!!
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
			Socket4.SendMessage ("DestroyBlock");
		}
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
			Socket4.SendMessage ("AddRedBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false && BlockInSocket == BlueBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			Socket4.SendMessage ("AddBlueBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false && BlockInSocket == GreenBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			Socket4.SendMessage ("AddGreenBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false && BlockInSocket == YellowBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			Socket4.SendMessage ("AddYellowBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
	}
}