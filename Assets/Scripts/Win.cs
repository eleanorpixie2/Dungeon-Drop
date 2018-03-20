using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

	//Button object 
	public Button button;

	//Text to display score
	Text Score_UIText;


	// Use this for initialization
	void Start () {

		//Gets button component and assin a task
		Button btn = button.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);

		//Assigns text component
		Score_UIText=GameObject.FindWithTag ("Score").GetComponent<Text> ();

	}

	void Update(){

		//Displays score text
		Score_UIText.text = Convert.ToString ("Final Score: " + ScoreStorer.Score);

	}

	void TaskOnClick(){

		//Loads scene 3 when corresponding button is pressed
		SceneManager.LoadScene ("3");

	}
		
}
