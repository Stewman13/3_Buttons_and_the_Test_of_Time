using UnityEngine;
using System.Collections;

public class S_Socket_4 : MonoBehaviour {

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
			Socket5.SendMessage ("Emptying");
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

	void Emptying(){
		if (Empty == false && BlockInSocket == RedBlock){
			Destroy (BlockInPlace);
			Socket3.SendMessage ("AddRedBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false && BlockInSocket == BlueBlock){
			Destroy (BlockInPlace);
			Socket3.SendMessage ("AddBlueBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false && BlockInSocket == GreenBlock){
			Destroy (BlockInPlace);
			Socket3.SendMessage ("AddGreenBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
		if (Empty == false && BlockInSocket == YellowBlock){
			Destroy (BlockInPlace);
			Socket3.SendMessage ("AddYellowBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		}
	}
}
