using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maxil2Movement : MonoBehaviour {
    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    //currently not using this
    bool crouch = false;

    //This just refers to thye character if we need to reference it
    public GameObject player;

    //This refers to which side of the screen the player will be on when they are loaded in to a new scene
    static string screenSideOnLoad; //Will be left or right


    // Use this for initialization
    void Start()
    {
        if (screenSideOnLoad == "left")
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
    void Update()
    {
        //Use this function to get input for the character

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
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
