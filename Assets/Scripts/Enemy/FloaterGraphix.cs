using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FloaterGraphix : MonoBehaviour {

    public AIPath aiPath;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

	}
}
