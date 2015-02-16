using UnityEngine;
using System.Collections;

public class S_Menu_GameTitle : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		StartCoroutine(MU(4.0f));
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator MU(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel(1);
	}
}
