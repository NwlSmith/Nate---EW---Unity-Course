using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //store x speed of player
    public float xSpeed = 6.0f;
    //store jump speed of player
    public float ySpeed = 1000000000000.0f;
    // get rigitbody2d
    private Rigidbody2D rb2d;
    public bool alive = true;

    void Start()
    {
        //retrieve RigidBody2D from GameObject
        rb2d = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //check if player is alive 
        if (alive == true)
        {
            float moveX = Input.GetAxis("X");
            float moveY = Input.GetAxis("Y");

            //get current player velocity
            Vector2 targetVelocity = rb2d.velocity;
            //check if pressing key in x direction
            if (moveX != 0)
            {
                //change the currect x velocity
                targetVelocity.x = moveX * xSpeed;
            }
            //check if pressing key in y direction
            //AND check that you aren't already jumping
            if (moveY > 0 && rb2d.velocity.y == 0)
            {
                GetComponent<AudioSource>().Play();
                //change the currect y velocity
                targetVelocity.y = ySpeed;
            }
            rb2d.velocity = targetVelocity;
        }
    }
    //check collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            {
            alive = false;
            }
    }

}
