using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMove : MonoBehaviour {

	Vector3 up1 = new Vector3(0, 0, 0),
	up2 = new Vector3(0, 180, 0),
	right = new Vector3(0, 90, 0),
	down = new Vector3(0, 180, 0),
	left = new Vector3(0, 270, 0),
	currentDirection;

	Vector3 nextPos, destination, direction;

	float mSpeed = 2.0f;
	float rayLength = 1.0f;
	int number = 0;
	public static int movesY = 0;
	public static int movesX = 0;

	//P1
	public static int movesYP1 = 0;
	public static int movesXP1 = 0;
	//P2
	public static int movesYP2 = 0;
	public static int movesXP2 = 0;

	Vector3 actualMove;

	public static bool movingPlayer = false;
	public static bool canAttack = true;

	public TurnHandler makeSwitch;

	// Use this for initialization
	void Start () {

		makeSwitch = GameObject.FindGameObjectWithTag("GameController").GetComponent<TurnHandler>();

		if(gameObject.tag == "PlayerOne"){
			currentDirection = up1;
			currentDirection = Vector3.zero;
		}
		if(gameObject.tag == "PlayerTwo"){
			currentDirection = up2;
			currentDirection = down;
		}
		nextPos = Vector3.forward;
		destination = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		listenPlayerMove ();
		if(Input.GetKeyDown(KeyCode.J)){
			Debug.Log(GameControllerScript.currentTurn);
		}
		
	}

	void RollDice(){
		movingPlayer = true;
		if(GameControllerScript.currentTurn == 1){
			//roll dice p1
			movesYP1 = Random.Range (1,7);
			movesXP1 = Random.Range (1,7);
			Debug.Log ("Y: " + movesYP1 + " X: " + movesXP1);
		}
		if(GameControllerScript.currentTurn == 2){
			movesYP2 = Random.Range (1,7);
			movesXP2 = Random.Range (1,7);
			Debug.Log ("Y: " + movesYP2 + " X: " + movesXP2);
		}

		//number = Random.Range (1,7);
		//movesY = number;
		//number = Random.Range (1,7);
		//movesX = number;
		//Debug.Log ("Y: " + movesY + " X: " + movesX);

	}

	void listenPlayerMove(){

		if (GameControllerScript.matchIsStarted) {

			if(GameControllerScript.currentTurn == 1){
				if(gameObject.tag == "PlayerOne"){
					MovePlayer ();
				}
			}
			if(GameControllerScript.currentTurn == 2){
				if (gameObject.tag == "PlayerTwo") {
					MovePlayer ();
				}
			}

		}
		
	}

	void MovePlayer(){

		if (Input.GetKeyDown (KeyCode.R)) {
			canAttack = true;
			RollDice ();
		}

		InAttackRange ();

		if(GameControllerScript.currentTurn == 1){
			if(movesYP1 > 0){
				if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
					currentDirection = up1;
					transform.localEulerAngles = currentDirection;
					gameObject.transform.Translate (new Vector3 (0, 0, 1));
					movesYP1 -= 1;
				}
				if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
					currentDirection = down;
					transform.localEulerAngles = currentDirection;
					gameObject.transform.Translate (new Vector3 (0, 0, 1));
					movesYP1 -= 1;
				}
			}
			if(movesXP1 > 0){
				if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow)){
					currentDirection = left;
					transform.localEulerAngles = currentDirection;
					gameObject.transform.Translate (new Vector3 (0, 0, 1));
					movesXP1 -= 1;
				}

				if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow)){
					currentDirection = right;
					transform.localEulerAngles = currentDirection;
					gameObject.transform.Translate (new Vector3 (0, 0, 1));
					movesXP1 -= 1;
				}
			}
		}

		if(GameControllerScript.currentTurn == 2){
			if(movesYP2 > 0){
				if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
					currentDirection = up1;
					transform.localEulerAngles = currentDirection;
					gameObject.transform.Translate (new Vector3 (0, 0, 1));
					movesYP2 -= 1;
				}
				if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
					currentDirection = down;
					transform.localEulerAngles = currentDirection;
					gameObject.transform.Translate (new Vector3 (0, 0, 1));
					movesYP2 -= 1;
				}
			}
			if(movesXP2 > 0){
				if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow)){
					currentDirection = left;
					transform.localEulerAngles = currentDirection;
					gameObject.transform.Translate (new Vector3 (0, 0, 1));
					movesXP2 -= 1;
				}

				if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow)){
					currentDirection = right;
					transform.localEulerAngles = currentDirection;
					gameObject.transform.Translate (new Vector3 (0, 0, 1));
					movesXP2 -= 1;
				}
			}
		}

		/*
		if(movesY > 0){
			if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
				currentDirection = up1;
				transform.localEulerAngles = currentDirection;
				gameObject.transform.Translate (new Vector3 (0, 0, 1));
				movesY -= 1;
			}

			if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
				currentDirection = down;
				transform.localEulerAngles = currentDirection;
				gameObject.transform.Translate (new Vector3 (0, 0, 1));
				movesY -= 1;
			}
		}
		*/
		/*
		if(movesX > 0){
			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow)){
				currentDirection = left;
				transform.localEulerAngles = currentDirection;
				gameObject.transform.Translate (new Vector3 (0, 0, 1));
				movesX -= 1;
			}

			if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow)){
				currentDirection = right;
				transform.localEulerAngles = currentDirection;
				gameObject.transform.Translate (new Vector3 (0, 0, 1));
				movesX -= 1;
			}
		}
		*/

		if(GameControllerScript.currentTurn == 1){

			if(movesYP1 == 0 && movesXP1 == 0 && movingPlayer == true){
				//chooseNextPlayer ();
				//movingPlayer = false;
				//activate switchTurns function in TurnHandler Script
				//GameControllerScript.turnSwitch();

				if (InAttackRange () == false) {
					movingPlayer = false;
					GameControllerScript.turnSwitch ();
					Debug.Log ("Ended Turn Successfuly");
				}

				if(Input.GetKeyDown(KeyCode.E)){
				}
				//AttackPlayer ();

				//GameControllerScript.turnSwitch();

			}
			
		}
		if(GameControllerScript.currentTurn == 2){

			if(movesYP2 == 0 && movesXP2 == 0 && movingPlayer == true){
				//chooseNextPlayer ();
				//movingPlayer = false;
				//activate switchTurns function in TurnHandler Script
				//GameControllerScript.turnSwitch();

				if(InAttackRange() == false){
					movingPlayer = false;
					GameControllerScript.turnSwitch ();
					Debug.Log ("Ended Turn Successfuly");
				}
				//GameControllerScript.turnSwitch();

			}
			
		}

		/*
		if(movesY == 0 && movesX == 0 && movingPlayer == true){
			//chooseNextPlayer ();
			movingPlayer = false;
			Debug.Log ("Ended Turn Successfuly");
			//activate switchTurns function in TurnHandler Script
			//GameControllerScript.turnSwitch();
			GameControllerScript.turnSwitch();

		}
		*/

	}

	public bool InAttackRange(){
		
		Ray validationRayForward = new Ray (transform.position + new Vector3 (0, 0.50f, 0), transform.forward);
		Ray validationRayLeft = new Ray (transform.position + new Vector3 (0, 0.50f, 0), -transform.right);
		Ray validationRayRight = new Ray (transform.position + new Vector3 (0, 0.50f, 0), transform.right);
		Ray validationRayBack = new Ray (transform.position + new Vector3 (0, 0.50f, 0), -transform.forward);
		RaycastHit hit;

		Debug.DrawRay (validationRayForward.origin, validationRayForward.direction, Color.green);
		Debug.DrawRay (validationRayLeft.origin, validationRayLeft.direction, Color.green);
		Debug.DrawRay (validationRayRight.origin, validationRayRight.direction, Color.green);
		Debug.DrawRay (validationRayBack.origin, validationRayBack.direction, Color.green);

		if (Physics.Raycast (validationRayForward, out hit, rayLength)) {
			if (hit.collider.tag == "PlayerOne" || hit.collider.tag == "PlayerTwo") {
				Debug.DrawRay (validationRayForward.origin, validationRayForward.direction, Color.red);
				AttackPlayer ();
				return true;
				//Debug.Log ("Seeing from front");
			}
		}
		if (Physics.Raycast (validationRayLeft, out hit, rayLength)) {
			if (hit.collider.tag == "PlayerOne" || hit.collider.tag == "PlayerTwo") {
				Debug.DrawRay (validationRayLeft.origin, validationRayLeft.direction, Color.red);
				AttackPlayer ();
				return true;
				//Debug.Log ("Seeing from left");
			}
		}
		if (Physics.Raycast (validationRayRight, out hit, rayLength)) {
			if (hit.collider.tag == "PlayerOne" || hit.collider.tag == "PlayerTwo") {
				Debug.DrawRay (validationRayRight.origin, validationRayRight.direction, Color.red);
				AttackPlayer ();
				return true;
				//Debug.Log ("Seeing from right");
			}
		}
		if (Physics.Raycast (validationRayBack, out hit, rayLength)) {
			if (hit.collider.tag == "PlayerOne" || hit.collider.tag == "PlayerTwo") {
				Debug.DrawRay (validationRayBack.origin, validationRayBack.direction, Color.red);
				AttackPlayer ();
				return true;
				//Debug.Log ("Seeing from back");
			}
		}
		return false;

	}

	public void AttackPlayer(){
		if(Input.GetKeyDown(KeyCode.Y)){
			//Atack
			if(gameObject.tag == "PlayerOne" && canAttack == true){
				movesYP1 = 0;
				movesXP1 = 0;
				PlayerManager.playerTwoHealth -= 1;
				canAttack = false;
				GameControllerScript.turnSwitch ();
			}
			if(gameObject.tag == "PlayerTwo" && canAttack == true){
				movesYP2 = 0;
				movesXP2 = 0;
				PlayerManager.playerOneHealth -= 1;
				canAttack = false;
				GameControllerScript.turnSwitch ();
			}
			//GameControllerScript.turnSwitch ();
			//Debug.Log (PlayerManager.playerHealth);
			//PlayerManager.playerHealth -= 1;
			//Debug.Log (PlayerManager.playerHealth);
		}
	}

}
