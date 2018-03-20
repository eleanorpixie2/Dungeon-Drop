using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	//Creates 2 button objects
	public Button button;

	public Button button1;

	// Use this for initialization
	void Start () {

		//Sets one button with the set object's button component and then calls a method when the button is pressed
		Button btn = button.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);

		//Sets the other button with the set object's button component and then calls a method when the button is pressed
		Button btn1 = button1.GetComponent<Button> ();
		btn1.onClick.AddListener (TaskOnClick1);
	
	}

	//Loads the instruction scene when the corresponding button is pressed
	void TaskOnClick(){

		SceneManager.LoadScene ("Instructions");
	
	}

	//Quits the application when the corresponding button is pressed
	void TaskOnClick1(){

		Application.Quit ();
	}
}
