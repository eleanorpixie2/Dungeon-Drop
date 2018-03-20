using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BossPlayerMovement : MonoBehaviour {
    //Speed and jump values for player
    public float speed;
    public float jump;

    //Variables used to check distance to colliders
    public GameObject rayOrigin;
    public float rayCheckDistance;

    //The components of the player object
    BoxCollider2D boxCollider;
    Rigidbody2D rb2D;

    //Makes the player invincible for a few seconds after being hit
	bool isInvincible;

	bool bossIsInvincible;

    //Time for a few seconds
    [SerializeField]
    float collisionDelay = 3f;

    //A list that contains the colliders for all the platforms
    List<BoxCollider2D> Platforms = new List<BoxCollider2D>();

	Vector2 Projectile;
	GameObject[] Projectiles;

	GameObject key;
	GameObject door;

	Text bLives;

	int hit=4;

    void Start()
    {
		StartCoroutine (Warning ());

		Projectiles = GameObject.FindGameObjectsWithTag ("EnemyHit");

		key = GameObject.FindGameObjectWithTag ("Key");
		door = GameObject.FindGameObjectWithTag ("Door");

		key.SetActive (false);
		door.SetActive (false);

		foreach (GameObject obj in Projectiles) 
		{
			obj.SetActive (false);
		}

		bLives = GameObject.FindGameObjectWithTag ("BossLives").GetComponent<Text> ();

        //Assigning the components for player
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();

        //Assigning the components for the platforms
        Platforms.Add(GameObject.FindGameObjectWithTag("Platform").GetComponent<BoxCollider2D>());
        Platforms.Add(GameObject.FindGameObjectWithTag("Platform1").GetComponent<BoxCollider2D>());
        Platforms.Add(GameObject.FindGameObjectWithTag("Platform2").GetComponent<BoxCollider2D>());
        Platforms.Add(GameObject.FindGameObjectWithTag("Platform3").GetComponent<BoxCollider2D>());
        Platforms.Add(GameObject.FindGameObjectWithTag("Platform4").GetComponent<BoxCollider2D>());
        Platforms.Add(GameObject.FindGameObjectWithTag("Platform5").GetComponent<BoxCollider2D>());
    }

    void FixedUpdate()
    {
        //Gets the info for inputs that change the horizontal axis
        float x = Input.GetAxis("Horizontal");
        //Freezes the character so that it doesn't rotate on collision
        rb2D.freezeRotation = true;

		bLives.text = Convert.ToString ("Boss Lives: " + hit);
	
		if (hit > 0) 
		{
			StartCoroutine (dObjects ());
		}
        
		
        //Checks to see if the player object is on a platform before it can move
        if ((boxCollider.IsTouching(Platforms[0])) || (boxCollider.IsTouching(Platforms[1])) || (boxCollider.IsTouching(Platforms[2])) || (boxCollider.IsTouching(Platforms[3]))
            || (boxCollider.IsTouching(Platforms[4])) || (boxCollider.IsTouching(Platforms[5])))
        {

            //Allows the player object to jump when certain key input is recieved 
            if (Input.GetAxis("Jump") > 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, Vector2.down, rayCheckDistance);
                if (hit.collider != null)
                {
                    rb2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                }
            }
            //Moves the character either horizontally or vertically
            rb2D.velocity = new Vector3(x * speed, rb2D.velocity.y, 0);
        }


    }

    //Checks for collisions with other objects
    void OnTriggerEnter2D(Collider2D col)
    {

        //If the character is not invincible and collides with an enemy then subtract a life
        //and make invincible

        /*if (col.gameObject.tag == "EnemyCollider") {
			
				Destroy (col.transform.parent.gameObject);

		}*/

		if (col.gameObject.tag == "Enemy") 
		{ 
			if (bossIsInvincible == false) 
			{
				float disy = 0;
				float disx = 0;
				disy = (boxCollider.transform.position.y - col.gameObject.transform.position.y);
				disx = (boxCollider.transform.position.x - col.gameObject.transform.position.x);
				if (disy < 3 && disx < .8) {
					if (hit > 1 && hit <= 4) {
						hit--;
					} else if (hit <= 1) {
						hit = 0;
						Destroy (col.gameObject);
						key.SetActive (true);
						door.SetActive (true);
						ScoreStorer.Score += 100;
					}
					StartCoroutine (BossInvincible ());
				}
			}
            
		}

        if (col.gameObject.tag == "EnemyHit")
        {
            if (isInvincible == false)
            {
                ScoreManager.Life();
                StartCoroutine(Invincible());
                Debug.Log(ScoreStorer.Lives);
				col.gameObject.SetActive (false);
				col.gameObject.transform.position = Projectile;
            }
        }


        //If the character hits the floor, respawn it to the starting location
        if (col.gameObject.tag == "Floor")
        {

            ScoreManager.Respawning();
            Debug.Log("Respawn");
        }

   

        //If the player collides with a coin, then destroy it and increase the score
        if (col.gameObject.tag == "Orb")
        {
            Destroy(col.gameObject);
            ScoreStorer.Orb();
            Debug.Log(ScoreStorer.Score);
        }


        if (col.gameObject.tag == "Heart")
        {
            Destroy(col.gameObject);
            ScoreStorer.Lives += 1;
        }

		if (ScoreManager.hasKey == true) {

			//If the player collides with the door, then they escape and win
			if (col.gameObject.tag == "Door") {
				ScoreManager.Win ();
			}
		}

		//If the player collides with the key, then destroy it and set the hasKey variable to true
		if (col.gameObject.tag == "Key") {
			Destroy (col.gameObject);
			ScoreManager.Key ();
		}

    }


    //Makes the character invincible for a specific amount of seconds when called
    IEnumerator Invincible()
    {

        isInvincible = true;
        Debug.Log("True");
        yield return new WaitForSeconds(collisionDelay);
        Debug.Log("false");
        isInvincible = false;
    }

	IEnumerator BossInvincible()
	{

		bossIsInvincible = true;
		Debug.Log("True");
		yield return new WaitForSeconds(1);
		Debug.Log("false");
		bossIsInvincible = false;
	}

	IEnumerator Warning()
	{
		GameObject warning=GameObject.FindGameObjectWithTag("Warning");
		yield return new WaitForSeconds(5);
		warning.SetActive (false);

	}

	IEnumerator dObjects()
	{
        while (ScoreStorer.Lives>=0) {
            foreach (GameObject obj in Projectiles)
            {
                obj.SetActive(true);
                if (obj.GetComponent<BoxCollider2D>().IsTouching(Platforms[0]) || obj.GetComponent<BoxCollider2D>().IsTouching(Platforms[1]) ||
           obj.GetComponent<BoxCollider2D>().IsTouching(Platforms[2]) || obj.GetComponent<BoxCollider2D>().IsTouching(Platforms[3]) ||
           obj.GetComponent<BoxCollider2D>().IsTouching(Platforms[4]) || obj.GetComponent<BoxCollider2D>().IsTouching(Platforms[5]))
                {
					Projectile = obj.transform.position;
                    obj.SetActive(false);
                    obj.transform.position = Projectile;
                }


                yield return new WaitForSeconds(2);
				/*if (hit <= 0) 
				{
					break;
				}*/


            }
        }

	}


}
