using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	//The object that holds the gameobject I don't want destroyed
	public GameObject Dont;
		// Use this for initialization
	void Start () {
		//Makes sure the object isn't destroyed when the next scene is loaded
		DontDestroyOnLoad (Dont);
	}

		// Update is called once per frame
	void Update () {

	}
			
}
