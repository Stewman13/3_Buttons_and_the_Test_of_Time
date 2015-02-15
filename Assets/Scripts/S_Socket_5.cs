using UnityEngine;
using System.Collections;

public class S_Socket_5 : MonoBehaviour {

	
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
				StartCoroutine(WaitAndDestroy(0.01f));
				HitRight.collider.SendMessageUpwards ("BeingPoppedHrzntl"); 
				HitLeft.collider.SendMessageUpwards("BeingPoppedHrzntl");
			}
		}
	}

	
	//Set of 'add block' Recivers
	void AddRedBlock(){
		StartCoroutine(ARed(0.01f));
	}
	IEnumerator ARed(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = RedBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false){
			//!!!
		}
	}
	void AddBlueBlock(){
		StartCoroutine(AB(0.01f));
	}
	IEnumerator AB(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = BlueBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false){
			//!!!
		}
	}
	void AddGreenBlock(){
		StartCoroutine(AG(0.01f));
	}
	IEnumerator AG(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = GreenBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false){
			//!!!
		}
	}
	void AddYellowBlock(){
		StartCoroutine(AY(0.01f));
	}
	IEnumerator AY(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = YellowBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false){
			//!!!
		}
	}
	//End of Recivers	

	void DestroyBlock (){
		if (Empty == false){
			Destroy (BlockInPlace);
			SameColourLeft = false;
			SameColourRight = false;
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		else if (Empty == true){
			Socket4.SendMessage ("DestroyBlock");
		}
	}

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
		StartCoroutine(WaitAndDestroy(0.01f));
	}
	
	IEnumerator WaitAndDestroy(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		
		Destroy (BlockInPlace);
		SameColourLeft = false;
		SameColourRight = false;
		//Add 10 points!!
		BlockInSocket = EmptySocketBlock;
		BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		BlockInPlace.transform.parent = transform;
	}

	void Emptying(){
		if (Empty == false && BlockInSocket == RedBlock){
			Destroy (BlockInPlace);
			SameColourLeft = false;
			SameColourRight = false;
			Socket4.SendMessage ("AddRedBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false && BlockInSocket == BlueBlock){
			Destroy (BlockInPlace);
			SameColourLeft = false;
			SameColourRight = false;
			Socket4.SendMessage ("AddBlueBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false && BlockInSocket == GreenBlock){
			Destroy (BlockInPlace);
			SameColourLeft = false;
			SameColourRight = false;
			Socket4.SendMessage ("AddGreenBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false && BlockInSocket == YellowBlock){
			Destroy (BlockInPlace);
			SameColourLeft = false;
			SameColourRight = false;
			Socket4.SendMessage ("AddYellowBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
	}
}