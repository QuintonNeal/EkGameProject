using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public static int maxPlayerHealth = 5;
    public static int currentPlayerHealth = 5;

    //Set the prefab that will be loaded for hearts
    public GameObject heartPrefab;

    // Use this for initialization
    void Start () {
        updateHeartsOnScreen();
	}

    // Update is called once per frame
    //void Update () {
    //}


    //This might work with some tweaking
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Detected");
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            currentPlayerHealth--;
            Debug.Log(currentPlayerHealth);

            updateHeartsOnScreen(); //Call this function to show a graphical version of the player's health

            //Destroy player if he/she is out of hearts
            if (currentPlayerHealth <= 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
            }

        }
    }


    public void updateHeartsOnScreen()
    {
        //Delete the previous hearts before making new ones
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("PlayerHeart");
        foreach(GameObject obj in allObjects)
        {
            if (obj.transform.position.y > -5.0f)
            {
                Destroy(obj);
            }
        }

        
        float xCoordinate = -9.0f; // THis is the x coordinate of the hearts

        for (int i = 0; i < currentPlayerHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab) as GameObject; //Create the heart
            heart.transform.position = new Vector2(xCoordinate, -3.9f); //Give its location on the screen

            xCoordinate += 1.0f; //Add to the x coordinate to make the hearts go to the right
        }
        
    }

}
