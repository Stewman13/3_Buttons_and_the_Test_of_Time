using UnityEngine;
using System.Collections;

public class S_Next_Blocks_Controller : MonoBehaviour {

	public GameObject TowerSelected;

	public GameObject Tower1;
	public GameObject Tower2;
	public GameObject Tower3;
	public GameObject Tower4;
	public GameObject Tower5;

	public GameObject NextBlockTop;
	public GameObject NextBlockBottom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void SelectedTower1(){
		print ("tower 1 Selected");
		TowerSelected = Tower1;
		NextBlockTop.SendMessage ("SelectedTower1");
		NextBlockBottom.SendMessage ("SelectedTower1");
	}
	void SelectedTower2(){
		print ("tower 2 Selected");
		TowerSelected = Tower2;
		NextBlockTop.SendMessage ("SelectedTower2");
		NextBlockBottom.SendMessage ("SelectedTower2");
	}
	void SelectedTower3(){
		print ("tower 3 Selected");
		TowerSelected = Tower3;
		NextBlockTop.SendMessage ("SelectedTower3");
		NextBlockBottom.SendMessage ("SelectedTower3");
	}
	void SelectedTower4(){
		print ("tower 4 Selected");
		TowerSelected = Tower4;
		NextBlockTop.SendMessage ("SelectedTower4");
		NextBlockBottom.SendMessage ("SelectedTower4");
	}
	void SelectedTower5(){
		print ("tower 5 Selected");
		TowerSelected = Tower5;
		NextBlockTop.SendMessage ("SelectedTower5");
		NextBlockBottom.SendMessage ("SelectedTower5");
	}
}
