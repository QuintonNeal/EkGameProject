using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterHealth : MonoBehaviour {

    public int health = 100;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


    //Check to see if a bullet hits the enemy
    void OnTriggerEnter2D(Collider2D hitInfo) //hit info stores info abt what we hit
    {
        Bullet bullet = hitInfo.GetComponent<Bullet>();

        if (bullet != null)
        {
            TakeDamage(Bullet.damage);//If it was a bullet, deal damage equal to the damage of the bullet
        }
    }

}
