using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{

    private float speed;
    private Vector3 movementVector;
    private Vector2 posVector;
    private float startTime;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        int rotation = Random.Range(0, 360);
        transform.Rotate(0, 0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= 5 && gameObject.tag != "slowAsteroid") deleteAsteroid();
        else if (gameObject.tag == "slowAsteroid" && Time.time - startTime >= 20f) deleteAsteroid();
        transform.position += movementVector * Time.deltaTime;
        if (gameObject.tag == "slowAsteroid") transform.Rotate(0, 0, 1);
        else if (gameObject.tag == "fastAsteroid") transform.Rotate(0, 0, 4);
        else transform.Rotate(0, 0, 1.5f);
    }

    void startMove(float speed)
    {
        posVector = (Vector2.left);
        movementVector = posVector.normalized * speed;
    }

    void deleteAsteroid()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
