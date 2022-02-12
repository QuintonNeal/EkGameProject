using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float speed = 1.5f;
    private Rigidbody2D platform;

	// Use this for initialization
	void Start () {
        platform = this.GetComponent<Rigidbody2D>();

        //set the speed that the platform is moving
        platform.velocity = new Vector2(0, -speed);
	}
	
	// Update is called once per frame
	void Update () {

        //Reset the speed that the platform is moving. This keeps it a continuous speed, not changing
        platform.velocity = new Vector2(0, -speed);

    }
}
