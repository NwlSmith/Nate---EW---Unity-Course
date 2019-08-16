using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // store x speed of player
    public float xSpeed = 10.0f;
    // store jump speed of player
    public float jumpSpeed = 10.0f;
    // get rigidbody2d
    private Rigidbody2D rb2D;
    // keep track of if the player is alive
    public bool alive = true;
    // Start is called before the first frame update
    void Start()

    {// retrieve RigidBody2D from GameObject
        rb2D = GetComponent<Rigidbody2D>();

    }
    // FixedUpdate is called once per graphics frame
    void FixedUpdate()
    {
        //check if player is alive?
        if (alive == true)
        {
            //retrieve x input
            float moveX = Input.GetAxis("X");
            //retrieve y input
            float moveY = Input.GetAxis("Y");

            // get current player velocity
            Vector2 targetVelocity = rb2D.velocity;

            // check if pressing ket in x direction
            if (moveX != 0)
            {
                // chang the current x velocity
                targetVelocity.x = moveX * xSpeed;

            }

            // check if pressing the upkey in y direction
            // AND check that you aren't alresdy jumping
            if (moveY > 0 && rb2D.velocity.y == 0)
            {

                GetComponent<AudioSource>().Play();
                // chang the current y velocity
                targetVelocity.y = jumpSpeed;


            }
            // update RigidBodt2D
            rb2D.velocity = targetVelocity;
        }
    }
    // check collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if colliding with enemy
        if (collision.gameObject.tag == "Enemy")
        {
            // dead
            alive = false;
        }
    }
}

