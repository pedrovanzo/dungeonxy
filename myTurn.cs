using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myTurn : MonoBehaviour {

	private GameObject playerPrefab;
	private TempPlayerMove turnScript;
	//private bool oneIsPlaying = false;
	//private bool twoIsPlaying = false;

	// Use this for initialization
	void Start () {
		
		turnScript = GetComponent<TempPlayerMove> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		listenPlayerOneMove ();
		listenPlayerTwoMove ();

		setCurrentPlayerScript ();
		//chooseNextPlayer ();
		
	}

	//func choose next player
	//if gameover() {return}
	//if current == 1 {current = 2}
	//if current == 2 {current = 1}

	public void chooseNextPlayer(){
		if (GameControllerScript.currentTurn == 1) {
			GameControllerScript.currentTurn = 2;
		}
		if(GameControllerScript.currentTurn == 2){
			GameControllerScript.currentTurn = 1;
		}
	}

	void listenPlayerOneMove(){

		//Player one's turn
		//if (Input.GetKeyDown(KeyCode.X)){
		if (GameControllerScript.matchIsStarted && Input.GetKeyDown(KeyCode.X)){
			GameControllerScript.currentTurn = 1;
			Debug.Log (GameControllerScript.currentTurn);
			setCurrentPlayerScript ();
		}

	}

	void listenPlayerTwoMove(){

		//Player Two's turn
		if (GameControllerScript.matchIsStarted && Input.GetKeyDown(KeyCode.Z)){
			GameControllerScript.currentTurn = 2;
			Debug.Log (GameControllerScript.currentTurn);
			setCurrentPlayerScript ();
		}

	}

	public void setCurrentPlayerScript(){


		if(GameControllerScript.currentTurn == 1){
			if(gameObject.tag == "PlayerOne"){
				turnScript.enabled = true;
			}
			if(gameObject.tag == "PlayerTwo"){
				turnScript.enabled = false;
			}
		}

		if(GameControllerScript.currentTurn == 2){
			if(gameObject.tag == "PlayerOne"){
				turnScript.enabled = false;
			}
			if(gameObject.tag == "PlayerTwo"){
				turnScript.enabled = true;
			}
		}

	}

}
