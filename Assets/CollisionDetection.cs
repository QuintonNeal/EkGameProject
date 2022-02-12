using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    //If this game object touches the barrier at the bottom of the screen, it will be destroyed
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Colider - Platform Deletion")
        {
            Destroy(gameObject);
        }
    }
}
