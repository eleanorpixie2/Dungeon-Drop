using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStorer : MonoBehaviour {

	//the variable that stores the player score
	public static int Score;

	public static int Lives;

	public static int Level;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		//Sets the intial score to zero
		Score = 0;

		Lives = 3;

		Level = 1;
	}
	
	public static void Orb(){

		//Increases the score by increments of 10 everytime a coin is collected
		Score += 10;
	}

	public static void DestroyEnemy(){

		Score += 20;
	}

}
