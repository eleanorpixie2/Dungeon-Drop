using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {

	//Creates button object
	public Button button;

	// Use this for initialization
	void Start () {

		//Gets button component and creates a task
		Button btn = button.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick () {

		//Loads scene 1 when corresponding button is pressed
		SceneManager.LoadScene ("1");
		
	}
}
