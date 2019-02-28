using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Global Variable


    // this represents the rigidbody of our sprite
    // it has things like velocity which we can modify when we move our player
    private Rigidbody2D rb2D;

    // variable to store horizontal speed of player
    public float horizontalSpeed = 10.0f;

    // variable to store vertical speed of the player
    public float jumpSpeed = 10.0f;



    // Start is called before the first frame update
    void Start()
    {
        // get and store rigid body from sprite so we can change it
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per pysics frame
    void FixedUpdate()
    {
        // if the player is currently alive..

        // get input from the keyboard keys and store in float variable
        // ad left right arrows
        float moveHorizontal = Input.GetAxis("Horizontal");
        // ws up down arrows
        float moveVertical = Input.GetAxis("Vertical");

        // will store the current velocity of the player
        Vector2 targetVelocity = rb2D.velocity;

        // need to update left and right velocity
        // check to see if the player is pressing someting in the left or right axis!
        if (moveHorizontal != 0)
        {
            // need to change/update the player x velocity 
            targetVelocity.x = moveHorizontal * horizontalSpeed;
        }

        // check if the player is pressing just the up arrow or W
        if (moveVertical > 0 && rb2D.velocity.y == 0)
        {
            // add jump sound
            GetComponent<AudioSource>().Play();

            //set the velocity up and down of the player to a #
            targetVelocity.y = jumpSpeed;
        }



        // update the velocity of the player to our new velocity based on keyboard input 
        rb2D.velocity = targetVelocity;




    }
}
