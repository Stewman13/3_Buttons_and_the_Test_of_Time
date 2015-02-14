using UnityEngine;
using System.Collections;

public class S_Socket_1 : MonoBehaviour {


	public bool SameColourLeft = false;
	public bool SameColourRight = false;
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
		BlockInPlace.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		EmptySocket();
		RayCasts();
	}

	void EmptySocket(){
		if (BlockInSocket == EmptySocketBlock){
			Empty = true;
			Socket2.SendMessage ("Emptying");
		}
		else if (BlockInSocket != EmptySocketBlock){
			Empty = false;
		}
	}

	void RayCasts(){
		RaycastHit HitLeft;
		RaycastHit HitRight;

		Ray ColourCheckerLeft = new Ray(transform.position, Vector3.left);
		Ray ColourCheckerRight = new Ray(transform.position, Vector3.right);
		
		Debug.DrawRay(transform.position, Vector3.left * BlockGapDistance);
		Debug.DrawRay(transform.position, Vector3.right * BlockGapDistance);
		
		if(!Empty){
			if(Physics.Raycast(ColourCheckerRight, out HitRight, BlockGapDistance)){ 
				if(HitRight.collider.tag == "Red_Box"  && BlockInSocket == RedBlock){
					SameColourRight = true;
				}
				if(HitRight.collider.tag == "Blue_Box"  && BlockInSocket == BlueBlock){
					SameColourRight = true;
				}
				if(HitRight.collider.tag == "Green_Box"  && BlockInSocket == GreenBlock){
					SameColourRight = true;
				}
				if(HitRight.collider.tag == "Yellow_Box"  && BlockInSocket == YellowBlock){
					SameColourRight = true;
				}
				if(HitRight.collider.tag == "Empty_Socket"){
					SameColourRight = false;
				}
			}
			if(Physics.Raycast(ColourCheckerLeft, out HitLeft, BlockGapDistance)){ 
				if(HitLeft.collider.tag == "Red_Box"  && BlockInSocket == RedBlock){
					SameColourLeft = true;
				}
				if(HitLeft.collider.tag == "Blue_Box"  && BlockInSocket == BlueBlock){
					SameColourLeft = true;
				}
				if(HitLeft.collider.tag == "Green_Box"  && BlockInSocket == GreenBlock){
					SameColourLeft = true;
				}
				if(HitLeft.collider.tag == "Yellow_Box"  && BlockInSocket == YellowBlock){
					SameColourLeft = true;
				}
				if(HitLeft.collider.tag == "Empty_Socket"){
					SameColourLeft = false;
				}
			}
			if(SameColourLeft == true && SameColourRight == true){
				HitRight.collider.SendMessageUpwards ("BeingPoppedHrzntl"); 
				HitLeft.collider.SendMessageUpwards("BeingPoppedHrzntl");
				Destroy (BlockInPlace);
				SameColourLeft = false;
				SameColourRight = false;
				//Add 10 points!!!!!!!!!!!!!!!!!!!
				BlockInSocket = EmptySocketBlock;
				BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
				BlockInPlace.transform.parent = transform;
			}
		}
	}
	

	//Set of 'add block' Recivers
	void AddRedBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			print ("red detroyed");
			BlockInSocket = RedBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
			print ("and replaced");
		}
		if (Empty == false){
			Socket2.SendMessage ("AddRedBlock");
		}
	}
	void AddBlueBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			print ("blue detroyed");
			BlockInSocket = BlueBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
			print ("and replaced");
		}
		if (Empty == false){
			Socket2.SendMessage ("AddBlueBlock");
		}
	}
	void AddGreenBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			print ("green detroyed");
			BlockInSocket = GreenBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
			print ("and replaced");
		}
		if (Empty == false){
			Socket2.SendMessage ("AddGreenBlock");
		}
	}
	void AddYellowBlock(){
		if (Empty == true){
			Destroy (BlockInPlace);
			print ("yellow detroyed");
			BlockInSocket = YellowBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
			print ("and replaced");
		}
		if (Empty == false){
			Socket2.SendMessage ("AddYellowBlock");
		}
	}
	//End of Recivers


	void BeingPoppedVrtcl(){
		Destroy (BlockInPlace);
		SameColourLeft = false;
		SameColourRight = false;
		//Add 20 points!!
		BlockInSocket = EmptySocketBlock;
		BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		BlockInPlace.transform.parent = transform;
	}

	void BeingPoppedHrzntl(){
		Destroy (BlockInPlace);
		SameColourLeft = false;
		SameColourRight = false;
		//Add 10 points!!!!!!!!!!!!!!!!!!!
		BlockInSocket = EmptySocketBlock;
		BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		BlockInPlace.transform.parent = transform;
	}

	void DestroyBlock (){
		if (Empty == false){
			Destroy (BlockInPlace);
			SameColourLeft = false;
			SameColourRight = false;
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
	}
}
