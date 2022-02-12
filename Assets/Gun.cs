using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform firePoint;

    public GameObject bulletPrefab;

    public static float timeLeftClickHeld; //Tracks how long left click is held down for
    bool isLeftClicking = false; //Set to true while the player is left clicking

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Down");
            isLeftClicking = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Up");
            isLeftClicking = false;
            Shoot();
        }

        if (isLeftClicking)
        {
            timeLeftClickHeld += 1 * (Time.deltaTime * 2);//Time how long the click was held. Multiply it by two so it doesn't take forever to ramp up
        }
    }

    void Shoot()
    {
        //Only shoot if the player has bullets
        if (Inventory.currentBullets > 0)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Create the bullet

            Inventory.currentBullets -= 1; //make it so that there is one less bullet in inventory
            Inventory.updateAmoHudOnScreen();
        }
    }

    public float TimeLeftClickHeld()
    {
        return timeLeftClickHeld;
    }
}
