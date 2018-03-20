using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour {

	//Player gameObject
	public GameObject Character;

	//Variable that becomes true when player collects the key object
	public static bool hasKey;

	//Starting camera position that the camera will respawn to when the player object respawns
	public static Vector3 respawnCamera;

	//Checks if the player object is in the camera view
	Renderer playerIsVisible;

	//Text for the amount of lives the character has
	Text Lives_UI;

	//Text for the player score
	Text Score_UI;

	// Use this for initialization
	void Start () {

		//Gets the text component for the lives text
		Lives_UI = GameObject.FindWithTag ("LivesText").GetComponent<Text> ();

		//Gets the text component for the score text
		Score_UI = GameObject.FindWithTag ("ScoreText").GetComponent<Text> ();

		//Gets the component needed to check if the player object is in the camera view
		playerIsVisible = Character.GetComponent<Renderer> ();

		//Gets the original camera position 
		respawnCamera = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;

		//Makes sure the character doesn't have the key at the start of the game
		hasKey = false;

	}
	
	// Update is called once per frame
	void Update () {

		//If player lives is 0, then load the gameover scene
		if (ScoreStorer.Lives <= 0)
			SceneManager.LoadScene ("2");

		//The player object leaves the camera view then respawn to starting position
		if (!playerIsVisible.isVisible) {

			Respawning ();
		}

		//Calls the function that displays the lives and score for the player object
		Display ();

	}

	//Decreases the amount of lives until 0
	public static void Life (){

		if (ScoreStorer.Lives >= 1) {
			ScoreStorer.Lives = ScoreStorer.Lives - 1;
		}

	}

	//Displays the score and lives text
	void Display()
	{
		Lives_UI.text = Convert.ToString("Lives: " + ScoreStorer.Lives);
		Score_UI.text = Convert.ToString ("Score: " + ScoreStorer.Score);
	}

	//Respawns the character to the starting position
	public static void Respawning(){

		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		GameObject Camera = GameObject.FindGameObjectWithTag ("MainCamera");

		player.transform.position = new Vector2(6.7f,2f);

		Camera.transform.position = respawnCamera;


	}

	//Loads win scene if character makes it to the door with the key
	public static void Win(){
		
		if(ScoreStorer.Level==1) {
			ScoreStorer.Level = 2;
			SceneManager.LoadScene ("4");
		}
		else if (ScoreStorer.Level == 2) {
			ScoreStorer.Level = 3;
			SceneManager.LoadScene ("5");
		}
        else if (ScoreStorer.Level == 3)
        {
            ScoreStorer.Level = 4;
            SceneManager.LoadScene("Boss");
        }
        else if (ScoreStorer.Level == 4) {
			SceneManager.LoadScene ("Win");
		} 
	}
		

	//Sets the hasKey value to true when the player object collides with the key object
	public static void Key (){
		hasKey = true;
	}
		
}
