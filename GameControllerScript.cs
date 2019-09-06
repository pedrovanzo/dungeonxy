using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	//List of Player GameObjects
	public GameObject[] playerList;

	//List of GUI Elements
	//public Text[] scoreText;

	//Spawn Player @ Transform.StartP1, Transform.StartP2
	public Transform[] spawnLocation;

	//GUI Display Moves
	public Text[] guiMoves;

	//GUI Health Display
	public Text[] guiHealth;

	//Turn Mechanics
	public static int currentTurn = 0;

	//DEBUG
	//public PlayerMovement pmScript;
	public static bool matchIsStarted = false;

	// Use this for initialization
	void Start () {
	
		SpawnPlayers ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){

			StartUpGame ();

		}

		DisplayHealth ();
		DisplayMovesYX ();
	}


	void StartUpGame (){
		matchIsStarted = true;
		currentTurn = 1;
		Debug.Log (currentTurn);
	}

	public static void turnSwitch(){
		if(currentTurn == 1){
			currentTurn = 2;
			Debug.Log ("Current Turn = " + currentTurn);
		} else if(currentTurn == 2){
			currentTurn = 1;
			Debug.Log ("Current Turn = " + currentTurn);
		}
	}

	void SpawnPlayers (){
		
		GameObject a = Instantiate (playerList[0], spawnLocation[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
		GameObject b = Instantiate (playerList[1], spawnLocation[1].transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;

	}

	void DisplayMovesYX(){

		if(guiMoves[0].tag == "PlayerOne" && guiMoves[1].tag == "PlayerOne"){
			guiMoves[0].text = TempPlayerMove.movesYP1.ToString();
			guiMoves[1].text = TempPlayerMove.movesXP1.ToString();
		}

		if(guiMoves[2].tag == "PlayerTwo" && guiMoves[3].tag == "PlayerTwo"){
			guiMoves[2].text = TempPlayerMove.movesYP2.ToString();
			guiMoves[3].text = TempPlayerMove.movesXP2.ToString();
		}

	}

	void DisplayHealth(){
		if(guiHealth[0].tag == "PlayerOne"){
			guiHealth [0].text = PlayerManager.playerOneHealth.ToString();
		}
		if(guiHealth[1].tag == "PlayerTwo"){
			guiHealth [1].text = PlayerManager.playerTwoHealth.ToString();
		}
	}

}
