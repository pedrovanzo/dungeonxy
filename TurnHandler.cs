using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour {

	public TempPlayerMove turnScript;

	// Use this for initialization
	void Start () {
		turnScript = GetComponent<TempPlayerMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void turnSwitch(){

		if (GameControllerScript.currentTurn == 1) {
			if(gameObject.tag == "PlayerOne"){
				turnScript.enabled = true;
			}else if(gameObject.tag == "PlayerTwo"){
				turnScript.enabled = false;
			}

		} else if(GameControllerScript.currentTurn == 2){
			if(gameObject.tag == "PlayerTwo"){
				turnScript.enabled = true;
			} else if(gameObject.tag == "PlayerOne"){
				turnScript.enabled = false;
			}

		}
		
	}
}
