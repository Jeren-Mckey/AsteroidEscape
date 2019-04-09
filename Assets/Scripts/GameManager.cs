using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float elapsedTime;
    private float startTime1;
    private float startTime2;
    public GameObject smallAsteroid;
    public GameObject mediumAsteroid;
    public GameObject largeAsteroid;
    public GameObject hugeAsteroid;
    public GameObject slowAsteroid;
    public GameObject fastAsteroid;
    private float kilometers;
    private float hardElapsedTime;
    public float speed;
    private bool startHard;

    // Use this for initialization
    void Start()
    {
        kilometers = 0;
        startTime1 = Time.time;
        elapsedTime = .5f;
        hardElapsedTime = 4f;
        startHard = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime1 >= elapsedTime)
        {
        
            spawn();
            startTime1 = Time.time;
        }
        if (Time.time >= 5f && !startHard)
        {
            startHard = true;
            startTime2 = Time.time;
        }
        if (startHard)
        {
            if (Time.time - startTime2 >= hardElapsedTime)
            {
                spawnHard();
                startTime2 = Time.time;
            }
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
        float asteroid = Random.Range(0, 4);
        if (asteroid >= 3)
        {
            Instantiate(smallAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed);
        }
        else if (asteroid >= 2)
        {
            Instantiate(mediumAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed);
        }
        else if (asteroid >= 1)
        {
            Instantiate(largeAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed);
        }
        else
        {
            Instantiate(hugeAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed);
        }
    }


    public void spawnHard()
    {
        float spawnY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 10)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height - 10)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width + 200, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width + 200, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        float asteroid = Random.Range(0, 2);
        if (asteroid >= 1)
        {
            Instantiate(fastAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed * (speed / 4));
        }
        else
        {
            Instantiate(slowAsteroid, spawnPosition, Quaternion.identity).SendMessage("startMove", speed / (speed / 4));
        }
    }

    public static void addKilometers(float kilometers)
    {
        Score.addScore(kilometers);
    }
}
