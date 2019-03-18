using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 totalMovement;
    public int speed;
    private Rigidbody2D rb2d;
    private float inputX;
    private float inputY;
   
	// Use this for initialization
	void Start ()
    {
        transform.Rotate(0, 0, -90);
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        if (inputX != 0 || inputY != 0)
        {
            totalMovement = new Vector3(inputX, inputY, 0);
            rb2d.MovePosition(new Vector2(transform.position.x + totalMovement.x * speed * Time.deltaTime,
                transform.position.y + totalMovement.y * speed * Time.deltaTime));
        }
             
    }

   

}
