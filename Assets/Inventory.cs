using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    //Set the prefab that will be loaded for bullet hud
    public GameObject BulletHudPrefab;

    public static int maxBullets = 10;
    public static int currentBullets = 10;


    // Use this for initialization
    void Start () {
        updateAmoHudOnScreen();
        GameObject bulletHud = Instantiate(BulletHudPrefab) as GameObject; //Create the heart
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public static void updateAmoHudOnScreen()
    {
        //Delete the previous bullets before making new ones
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("AmmoHud");
        foreach (GameObject obj in allObjects)
        {
            if (obj.transform.position.y > -5.0f) //don't destory the prefab below the screen
            {
                Destroy(obj);
            }
        }


        float xCoordinate = -9.0f; // THis is the x coordinate of the bullets

        for (int i = currentBullets; i > 0; i--)
        {
            GameObject bulletHud = Instantiate(GameObject.FindGameObjectWithTag("AmmoHud")) as GameObject; //Create the bullet
            bulletHud.transform.position = new Vector2(xCoordinate, -4.7f); //Give its location on the screen

            xCoordinate += 1.0f; //Add to the x coordinate to make the hearts go to the right
        }

    }
}
