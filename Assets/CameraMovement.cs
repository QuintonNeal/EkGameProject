using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


    public Transform target;
    public Vector3 offset;

    public Transform camera;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void LateUpdate () {

        
        //Used to see the initial position of the camera
        Vector3 camerasOldPosition = new Vector3(0, 0, -10);



        //Make the camera follow the player
        transform.position = target.position + offset;

        //Make the camera stay at the same y coordinate
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        //Make the camera stay within the bounds of the background on the x coordinate
        if (target.position.x < -1.20)//left edge
        {
            transform.position = new Vector3(-1.20f, 0, transform.position.z);
        }
        else if (target.position.x > 1.35)//right edge
        {
            transform.position = new Vector3(1.35f, 0, transform.position.z);
        }

        //Used to see where the camera is in relation to its initial position, so we can update the hud accordingly. So it stays in one place on the screen
        Vector3 camerasNewPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        
        //Measures how much the camera has moved
        Vector3 camerasPositionChange = camerasOldPosition - camerasNewPosition;

        //Redraw the ammo and heart hud
        Inventory.updateAmoHudOnScreen();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().updateHeartsOnScreen();

        //Move the hearts so it's not static on the screen
        GameObject[] allHearts = GameObject.FindGameObjectsWithTag("PlayerHeart");
        foreach (GameObject obj in allHearts)
        {
            //obj.transform.parent = camera.transform;
            obj.transform.position -= camerasPositionChange;
        }

        //Do the same with the bullets
        GameObject[] allAmmoHud = GameObject.FindGameObjectsWithTag("AmmoHud");
        foreach (GameObject obj in allAmmoHud)
        {
            //obj.transform.parent = camera.transform;
            obj.transform.position -= camerasPositionChange;
        }
    }
}
