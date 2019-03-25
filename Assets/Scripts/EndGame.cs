using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
    private int lives = 3;
    private int currentLife;
    private float startTime;
    private float elapsedTime;
    private bool notStarted;
    private bool visible;
    public GameObject explosion;

    // Use this for initialization
    void Start ()
    {
        currentLife = lives;
        visible = true;
        notStarted = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (lives == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (currentLife > lives)
        {
            if (notStarted)
            {
                startTime = Time.time;
                elapsedTime = Time.time;
                notStarted = false;
            }
            if (Time.time - elapsedTime <= 2.5f)
            {
                
                GetComponent<Rigidbody2D>().isKinematic = true;
                if (Time.time - startTime >= .2f && visible == true)
                {
                    GetComponent<Renderer>().enabled = false;
                    visible = false;
                    startTime = Time.time;
                }
                else if (Time.time - startTime >= .2f && visible == false)
                {
                    GetComponent<Renderer>().enabled = true;
                    startTime = Time.time;
                    visible = true;
                }
            }
            else
            {
                elapsedTime = Time.time;
                GetComponent<Rigidbody2D>().isKinematic = false;
                GetComponent<Renderer>().enabled = true;
                notStarted = true;
                currentLife--;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag != "Wall")
        {
            lives--;
        }
    }
 
}
