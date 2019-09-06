using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

	public Material mat;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PlayerOne") || other.gameObject.CompareTag("PlayerTwo")){
			
			//Debug.Log ("Passou pelo collider");
			this.GetComponent<Renderer>().material = mat;

		}
		if (gameObject.tag == "MysteryBox") {
			
			float number = Random.Range (0,7);
			string mysteryItem = "";

			//Number = Mystery Item
			//0 = Nothing
			//1 = Dagger
			//2 = Blade
			//3 = Long Sword
			//4 = Shield lvl 1
			//5 = Shield lvl 2
			//6 = Damage = 1

			if (number == 0){
				mysteryItem = "Nothing";
			}
			if (number == 1){
				mysteryItem = "Dagger";
			}
			if (number == 2){
				mysteryItem = "Blade";
			}
			if (number == 3){
				mysteryItem = "Long Sword";
			}
			if (number == 4){
				mysteryItem = "Shield lvl 1";
			}
			if (number == 5){
				mysteryItem = "Shield lvl 2";
			}
			if (number == 6){
				mysteryItem = "Damage = 1";
			}

			//Debug.Log (mysteryItem);
			//Debug.Log ("Mystery Box = true");
		} else {
			//Debug.Log ("MB-FALSE");
		}
	}
}
