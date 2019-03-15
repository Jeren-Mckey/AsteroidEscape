using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 totalMovement;
    public int speed;
   
	// Use this for initialization
	void Start ()
    {
        transform.Rotate(0, 0, -90);
	}
	
	// Update is called once per frame
	void Update ()
    {
        totalMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += totalMovement * speed * Time.deltaTime;
    }

}
