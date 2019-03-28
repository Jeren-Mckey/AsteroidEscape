using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float elapsedTime;
    private float startTime;
    public GameObject smallAsteroid;
    public GameObject mediumAsteroid;
    public GameObject largeAsteroid;
    public GameObject hugeAsteroid;
    public GameObject explodingAsteroid;
    public GameObject fastAsteroid;
    private float kilometers;
    public float speed;

    // Use this for initialization
    void Start()
    {
        kilometers = 0;
        startTime = Time.time;
        elapsedTime = .5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= elapsedTime)
        {
            spawn();
            startTime = Time.time;
        }
        kilometers++;
        addKilometers(kilometers);
    }

    void spawn()
    {
        float spawnY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 10)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height - 10)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width + 200, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width + 200, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        float asteroid = Random.Range(1, 4);
        if (asteroid >= 4)
        {
            Instantiate(smallAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed);
        }
        else if (asteroid >= 3)
        {
            Instantiate(mediumAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed);
        }
        else if (asteroid >= 2)
        {
            Instantiate(largeAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed);
        }
        else
        {
            Instantiate(hugeAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed);
        }
    }

    public static void addKilometers(float kilometers)
    {
        Score.addScore(kilometers);
    }
}
