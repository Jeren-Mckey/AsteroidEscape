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
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= 5) deleteAsteroid();
        transform.position += movementVector * Time.deltaTime;
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
