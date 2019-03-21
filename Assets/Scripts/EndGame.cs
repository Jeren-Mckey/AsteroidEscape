using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
    private int lives = 3;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (lives == 0)
        {
            Debug.Log("Game Ended");
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag != "Wall")
        {
            lives--;
            Debug.Log(lives);
        }
    }
}
