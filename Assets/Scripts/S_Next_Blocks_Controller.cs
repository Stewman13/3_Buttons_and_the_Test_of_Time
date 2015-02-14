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
		TowerSelected = Tower1;
		NextBlockTop.SendMessage ("SelectedTower1");
	}
	void SelectedTower2(){
		TowerSelected = Tower2;
		NextBlockTop.SendMessage ("SelectedTower2");
	}
}
