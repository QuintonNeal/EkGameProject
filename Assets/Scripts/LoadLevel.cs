using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {


    //Gets the level that needs to be loaded
    public string levelToLoad;

    //Tells which side of the screen to load the character on --> will be left or right
    public string leftOrRightOnLoad;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This allows us to get info abt the game object we collided with. In thios case, we want to check to see if it was the player
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Player")
        {
            LoadScene(collisionGameObject);
        }
    }


    void LoadScene(GameObject player)
    {

        //move the character to the correct side of the screen depending on which level is loaded
        player.GetComponent<PlayerMovement>().setSceenSide(leftOrRightOnLoad);

        //Load a specific level based on the levelToLoad variable
        SceneManager.LoadScene(levelToLoad);
    }

}
