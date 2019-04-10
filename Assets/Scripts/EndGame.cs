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
    public GameObject ship1;
    private int lifePoints;
    public GameObject ship2;
    public GameObject[] spareParts;
    public GameObject explosion;

    // Use this for initialization
    void Start ()
    {
        currentLife = lives;
        visible = true;
        notStarted = true;
        lifePoints = 0;
        for (int i = 0; i < spareParts.Length; i++)
        {
            spareParts[i].GetComponent<Renderer>().enabled = false;
        }
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
                if (ship1.GetComponent<Renderer>().enabled == true) ship1.GetComponent<Renderer>().enabled = false;
                else if (ship2.GetComponent<Renderer>().enabled == true) ship2.GetComponent<Renderer>().enabled = false;
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
            else if (Time.time - elapsedTime > 2.5f)
            {
                GetComponent<Renderer>().enabled = true;
                visible = true;
                if (!GetComponent<Renderer>().IsVisibleFrom(Camera.main)) transform.position = new Vector3(0, 0, 0);
                GetComponent<Rigidbody2D>().isKinematic = false;
                notStarted = true;
                currentLife--;
            }
        }
        if (lifePoints == 5 && lives != 3)
        {
            lives++;
            currentLife++;
            if (lives == 2) ship2.GetComponent<Renderer>().enabled = true;
            else ship1.GetComponent<Renderer>().enabled = true;
            lifePoints = 0;
            for (int i = 0; i < spareParts.Length; i++) spareParts[i].GetComponent<Renderer>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag != "Wall" && col.collider.tag != "point")
        {
            lives--;
        }
        else if (col.collider.tag == "point")
        {
            lifePoints++;
            spareParts[lifePoints - 1].GetComponent<Renderer>().enabled = true;
            GameObject point = col.gameObject;
            Destroy(point);
        }
    }
 
}
