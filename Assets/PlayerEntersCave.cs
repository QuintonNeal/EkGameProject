using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntersCave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D hitInfo) //hit info stores info abt what we hit
    {
        if (hitInfo.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = true;

            GameObject miner = GameObject.Find("Goblin21");
            miner.GetComponent<Renderer>().enabled = true;
        }
    }
}
