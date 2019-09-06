using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {


	//public GameObject textObject;

	public static int playerOneHealth = 0;
	public static int playerTwoHealth = 0;

	// Use this for initialization
	void Start () {

		//textObject = GameObject;
		playerOneHealth = 5;
		playerTwoHealth = 5;
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	void displayMovesYX(){

		/*
		if (TempPlayerMove.movingPlayer == true) {
			if(gameObject.tag == "MovesYText"){
				gameObject.SetActive (true);
			} else if(gameObject.tag == "MovesXText"){
				gameObject.SetActive (true);
			}
		} else {
			if(gameObject.tag == "MovesYText"){
				gameObject.SetActive (false);
			}else if(gameObject.tag == "MovesXText"){
				gameObject.SetActive (false);
			}

		}
		*/

		/*
		if(gameObject.tag == "MovesYText"){
			scoreText[0].text = TempPlayerMove.movesY.ToString();
		} else if(gameObject.tag == "MovesXText"){
			scoreText[1].text = TempPlayerMove.movesX.ToString();
		}
		*/
	}
}
