using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float speed = 12.0f;//speed of bullet
    private float maxSpeed = 60.0f; //max speed a bullet can go
    private float kickbackMultiplier = -0.25f; //used to determine how much kickback will be applied to the character
    public static int damage = 50;//How much damage the bullet deals when it hits something
    public Rigidbody2D rb; //Refers to the bullet's rigid body

    Rigidbody2D playerRB;


    // Use this for initialization
    void Start () {

        //This if is just here to make it so that the bullet is at least going the base speed unit
        if (speed * Gun.timeLeftClickHeld < speed)
        {
            rb.velocity = transform.right * speed;

            playerRB = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Rigidbody2D>();//References the player's rigidbody
            
            if (playerRB.velocity.magnitude < 0.5)
            {
                playerRB.velocity = rb.velocity * kickbackMultiplier;
            }
        }
        else if (speed * Gun.timeLeftClickHeld <= maxSpeed)
        {
            rb.velocity = transform.right * speed * Gun.timeLeftClickHeld;
            
            playerRB = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Rigidbody2D>();//References the player's rigidbody
            playerRB.velocity = rb.velocity * kickbackMultiplier;
        }
        else
        {
            rb.velocity = transform.right * maxSpeed;

            playerRB = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Rigidbody2D>();//References the player's rigidbody
            playerRB.velocity = rb.velocity * kickbackMultiplier;
        }

        Gun.timeLeftClickHeld = 0.0f;//Set the time held back to zero
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D hitInfo) //hit info stores info abt what we hit
    {
        Destroy(gameObject);
    }
}
