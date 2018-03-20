using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//Creats 2 vector points
	public Vector2 pointA;
	public Vector2 pointB;

	//Creates a rigidbody object
	Rigidbody2D rb2D;

	void Start(){
		
		//sets rigibody object to the gameobject's component
		rb2D = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		//stops object from rotating
		rb2D.freezeRotation = true;

		//Moves object between 2 points
		transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time,1));
	}

}
