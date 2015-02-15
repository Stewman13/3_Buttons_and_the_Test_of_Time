using UnityEngine;
using System.Collections;

public class S_Socket_3 : MonoBehaviour {

	
	public bool SameColourAbove = false;
	public bool SameColourUnder = false;
	public bool SameColourLeft = false;
	public bool SameColourRight = false;
	public bool Empty = true;

	public float BlockGapDistance = 2;
	
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
		BlockPopper();
	}
	
	void EmptySocket(){
		if (BlockInSocket == EmptySocketBlock){
			Empty = true;
			Socket4.SendMessage ("Emptying");
		}
		else if (BlockInSocket != EmptySocketBlock){
			Empty = false;
		}
	}

	void RayCasts(){
		RaycastHit HitDown;
		RaycastHit HitUp;
		RaycastHit HitLeft;
		RaycastHit HitRight;
		
		
		Ray ColourCheckerUp = new Ray(transform.position, Vector3.up);
		Ray ColourCheckerDown = new Ray(transform.position, Vector3.down);
		Ray ColourCheckerLeft = new Ray(transform.position, Vector3.left);
		Ray ColourCheckerRight = new Ray(transform.position, Vector3.right);
		
		Debug.DrawRay(transform.position, Vector3.left * BlockGapDistance);
		Debug.DrawRay(transform.position, Vector3.right * BlockGapDistance);
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
				
				StartCoroutine(WaitAndDestroy(0.01f));
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
			StartCoroutine(AR(0.01f));
		}
		IEnumerator AR(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (Empty == true){
			Destroy (BlockInPlace);
			BlockInSocket = RedBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false){
			Socket4.SendMessage ("AddRedBlock");
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
			Socket4.SendMessage ("AddBlueBlock");
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
			Socket4.SendMessage ("AddGreenBlock");
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
			Socket4.SendMessage ("AddYellowBlock");
		}
	}
	//End of Recivers

	void DestroyBlock (){
		if (Empty == false){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			SameColourLeft = false;
			SameColourRight = false;
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		else if (Empty == true){
			Socket2.SendMessage ("DestroyBlock");
		}
	}

	void PopVrtcl(){
		Destroy (BlockInPlace);
		SameColourUnder = false;
		SameColourAbove = false;
		SameColourLeft = false;
		SameColourRight = false;
		//Add 20 points!!!!!!!!!!!!!!!!!!!
		BlockInSocket = EmptySocketBlock;
		BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
		BlockInPlace.transform.parent = transform;
		Socket2.SendMessage("BeingPoppedVrtcl"); 
		Socket4.SendMessage("BeingPoppedVrtcl");
	}

	void BeingPoppedVrtcl(){
		Destroy (BlockInPlace);
		SameColourUnder = false;
		SameColourAbove = false;
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
		SameColourUnder = false;
		SameColourAbove = false;
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
			SameColourUnder = false;
			SameColourAbove = false;
			SameColourLeft = false;
			SameColourRight = false;
			Socket2.SendMessage ("AddRedBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false && BlockInSocket == BlueBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			SameColourLeft = false;
			SameColourRight = false;
			Socket2.SendMessage ("AddBlueBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false && BlockInSocket == GreenBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			SameColourLeft = false;
			SameColourRight = false;
			Socket2.SendMessage ("AddGreenBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
		if (Empty == false && BlockInSocket == YellowBlock){
			Destroy (BlockInPlace);
			SameColourUnder = false;
			SameColourAbove = false;
			SameColourLeft = false;
			SameColourRight = false;
			Socket2.SendMessage ("AddYellowBlock");
			BlockInSocket = EmptySocketBlock;
			BlockInPlace = Instantiate(BlockInSocket, transform.position, transform.rotation) as GameObject;
			BlockInPlace.transform.parent = transform;
		}
	}
}
