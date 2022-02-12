using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour {
    
    //Set the prefab that will be loaded
    public GameObject platformPrefab;

    //When this hits zero, a new platform will load into the screen
    private float targetTime = 1.1f;

    bool timerEnded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (timerEnded == false)
        {
            targetTime -= 1 * Time.deltaTime;

            if (targetTime < 0.0f)
            {
                TimerEnded();
            }
        }
	}

    private void TimerEnded()
    {
        timerEnded = true;

        //Spawn in the object
        SpawnPlatform();
    }

    private void SpawnPlatform()
    {
        GameObject a = Instantiate(platformPrefab) as GameObject;

        //ensure that the platforms aren't spawned off the screen
        if (this.transform.position.x <= -3.0f)
        {
            //Set the new objects position relative to the current object
            a.transform.position = new Vector2((this.transform.position.x + (Random.Range(2.0f, 4.0f))), 5.5f);
            Debug.Log("Left Barrier");
        }
        else if (this.transform.position.x >= 3.0f)
        {
            //Set the new objects position relative to the current object
            a.transform.position = new Vector2((this.transform.position.x + (Random.Range(-4.0f, -2.0f))), 5.5f);
            hitRightBarrier.hitRight = true;
            Debug.Log("Right Barrier");
        }
        else
        {
            if (hitRightBarrier.hitRight == true)
            {
                //Choose a random direction to go in
                float RandomNum = Random.Range(1, 2);

                //Set the new objects position relative to the current object
                if (RandomNum < 1.2)
                {
                    a.transform.position = new Vector2((this.transform.position.x + (Random.Range(2.0f, 4.0f))), 5.5f);
                }
                else if (RandomNum >= 1.2)
                {
                    a.transform.position = new Vector2((this.transform.position.x + (Random.Range(-4.0f, -2.0f))), 5.5f);
                }
            }
            else
            {
                //Choose a random direction to go in
                float RandomNum = Random.Range(1, 2);

                //Set the new objects position relative to the current object
                if (RandomNum < 1.5)
                {
                    a.transform.position = new Vector2((this.transform.position.x + (Random.Range(2.0f, 4.0f))), 5.5f);
                    Debug.Log("Going Right");
                }
                else if (RandomNum >= 1.5)
                {
                    a.transform.position = new Vector2((this.transform.position.x + (Random.Range(-4.0f, -2.0f))), 5.5f);
                    Debug.Log("Going Left");
                }
            }
        }
    }
}
