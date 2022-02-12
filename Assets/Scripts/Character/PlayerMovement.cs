using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Test comment for git

    public CharacterController2D controller;

    public Animator animator;

    public Transform firePoint;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    bool firePointJumpTrigger = false; //used to move the firepoint up and down for when the player jumps

    string characterMovingDirection = "Right"; //Will be Left or Right

    //currently not using this
    bool crouch = false;

    //This just refers to thye character if we need to reference it
    public GameObject player;

    //This refers to which side of the screen the player will be on when they are loaded in to a new scene
    static string screenSideOnLoad; //Will be left or right


    // Use this for initialization
    void Start ()
    {
        if(screenSideOnLoad == "left")
        {
            Vector3 spawnPoint = GameObject.Find("LeftSpawn").transform.position;
            transform.position = spawnPoint;
            //transform.position = new Vector3(-9, 2, 0);
        }
        else if (screenSideOnLoad == "right")
        {
            Vector3 spawnPoint = GameObject.Find("RightSpawn").transform.position;
            transform.position = spawnPoint;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Use this function to get input for the character

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (horizontalMove < 0)
        {
            characterMovingDirection = "Left";
        }

        if (horizontalMove > 0)
        {
            characterMovingDirection = "Right";
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        //Move the FirePoint down if the player is jumping
        if (jump == true && firePointJumpTrigger == false)
        {
            if (characterMovingDirection == "Right")
            {
                firePoint.transform.position = new Vector2(player.transform.position.x + 0.2f, player.transform.position.y - 0.5f);//change the location
            }
            if (characterMovingDirection == "Left")
            {
                firePoint.transform.position = new Vector2(player.transform.position.x - 0.2f, player.transform.position.y - 0.5f);//change the location
            }

            //firePoint.transform.position = new Vector2(firePoint.transform.position.x, firePoint.transform.position.y - 0.5f);//change the location
            firePoint.transform.rotation = Quaternion.Euler(0, 0, 270);//change the rotation
            firePointJumpTrigger = true;
        }
        

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
	}

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);

        //Move the FirePoint up when the player lands
        if (firePointJumpTrigger == true)
        {
            //firePoint.transform.position = new Vector2(firePoint.transform.position.x, firePoint.transform.position.y + 0.5f);//change the location
            
            if (characterMovingDirection == "Right")
            {
                firePoint.transform.rotation = Quaternion.Euler(0, 0, 0);//change the rotation
                firePoint.transform.position = new Vector2(player.transform.position.x + 0.35f, player.transform.position.y - 0.04f);//change the location
            }
            else if (characterMovingDirection == "Left")
            {
                firePoint.transform.rotation = Quaternion.Euler(0, 0, 180);//change the rotation
                firePoint.transform.position = new Vector2(player.transform.position.x - 0.35f, player.transform.position.y - 0.04f);//change the location
            }

            firePointJumpTrigger = false;
        }
    }


    //Update is called a fixed amount of times in one second, unlike update function where it's called once everytime a frame is drawn
    private void FixedUpdate()
    {
        //Move the character in this function

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void setSceenSide(string leftOrRight)
    {
        if (leftOrRight == "left")
        {
            screenSideOnLoad = "left";
        }
        else if (leftOrRight == "right")
        {
            screenSideOnLoad = "right";
        }
    }
}
