using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Restart_GameOver : MonoBehaviour {

	//Declares the button objects
	public Button button;

	public Button button1;

	// Use this for initialization
	void Start () {

		//assigns the components for the button object 
		Button btn = button.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);

		//assigns the components for the button object 
		Button btn1 = button1.GetComponent<Button> ();
		btn1.onClick.AddListener (TaskOnClick1);

	}

	void TaskOnClick(){

		//Load scene one when corresponding button is pressed
		SceneManager.LoadScene ("1");

	}

	void TaskOnClick1(){

		//Load scene 3 when corresponding button is pressed
		SceneManager.LoadScene ("3");
	}
}
