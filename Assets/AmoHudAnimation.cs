using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoHudAnimation : MonoBehaviour {

    private bool done = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (done == false)
        {
            StartCoroutine(ammoWaiter());
            done = true;
        }*/

    }
    /*
    IEnumerator ammoWaiter()
    {
        yield return new WaitForSeconds(1.0f);// wait.. then run the below code

        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-30, 30));
        done = false;
    }*/
}
