using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    //The object need to assign the player object to so that the camera follows the player
    public Transform target;

	//Speed the camera follows the player object
    public float speed = 1.0f;


    // Use this for initialization
    void Start()
    {
    }

    void FixedUpdate()
    {
		//Prevents the camera from moving infinitely 
        if (target.position.y < 2 && target.position.y > -10.7)
        {
			//Moves the camera position
            Vector3 v3 = transform.position;
            v3.y = Mathf.Lerp(v3.y, target.position.y, Time.deltaTime * speed);
            transform.position = v3;
        }
    }
}
