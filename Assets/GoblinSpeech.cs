using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpeech : MonoBehaviour {

    bool withinTalkingDistance = false;

    //Used to track which speech bubble is visible
    bool firstBubbleShowing = false;
    bool secondBubbleShowing = false;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && withinTalkingDistance == true)
        {
            if (firstBubbleShowing == false && secondBubbleShowing == false)
            {
                GameObject speech1 = GameObject.Find("Goblin1Speech1");
                speech1.GetComponent<Renderer>().enabled = true;

                firstBubbleShowing = true;
            }
            else if (firstBubbleShowing == true && secondBubbleShowing == false)
            {
                GameObject speech2 = GameObject.Find("Goblin1Speech2");
                speech2.GetComponent<Renderer>().enabled = true;

                secondBubbleShowing = true;

                //Disable the speech1 bubble
                disableBubble1();
            }
            else
            {
                Inventory.currentBullets = 10;
                disableBubble1();
                disableBubble2();
            }
        }

    }



    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            GameObject talk = GameObject.Find("Interact Button");
            talk.transform.position = this.transform.position + new Vector3 (1, 0, 0);
            talk.GetComponent<Renderer>().enabled = true;
            withinTalkingDistance = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        withinTalkingDistance = false;

        //Disable the talk bubble
        GameObject talk = GameObject.Find("Interact Button");
        talk.GetComponent<Renderer>().enabled = false;

        //Disable the speech1 bubble
        disableBubble1();

        //Disable the speech2 bubble
        disableBubble2();

        //Note that the player is no longer within walking distance
        withinTalkingDistance = false;
    }

    private void disableBubble1()
    {
        //Disable the speech1 bubble
        GameObject speech1 = GameObject.Find("Goblin1Speech1");
        speech1.GetComponent<Renderer>().enabled = false;
        firstBubbleShowing = false;
    }

    private void disableBubble2()
    {
        //Disable the speech2 bubble
        GameObject speech2 = GameObject.Find("Goblin1Speech2");
        speech2.GetComponent<Renderer>().enabled = false;
        secondBubbleShowing = false;
    }
}
