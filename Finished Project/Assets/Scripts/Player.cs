using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // NEEDED FOR TEXT

public class Player : MonoBehaviour {

    // variable to store horizontal speed of player
    // because it is public, you will be able to change it from the inspector.
    // the player will move this many units per second.
    public float m_horizontalSpeed = 10f;
    // variable to store vertical speed of the player
    // the player will have their vertical velocity set to this value when jumping
    public float m_jumpSpeed = 10f;

    // variable that will hold the current score
    public int score = 0;

    // text that the current score will be displayed on - NEED using UnityEngine.UI;
    public Text scoreText;
    // text that will say that the player lost - NEED using UnityEngine.UI;
    public Text loseText;

    // Global Variable
    // go over what a variable is
    // stores a little bit of code that either says "yes", this is alive, or "no", this is not alive.
    private bool alive = true;

    // this is a reference to the rigidbody of our sprite
    // it contains variables for moving the gameobject, like velocity and force
    // we can modify these values to move our player
    private Rigidbody2D rb2D;

    private void Start()
    {
        // get and store the rigid body 2d from this game object so we can change it
        rb2D = GetComponent<Rigidbody2D>();
        // disable loseText so that it is not visible until the player loses
        loseText.enabled = false;
    }

    // FixedUpdate is called once per physics frame
    private void FixedUpdate()
    {
        // if the player is still alive, allow input
        if (alive)
        {
            // get input from the keyboard keys and store in float variable from -1 to 1
            // -1 for left, +1 for right
            // when there is no input, this value will go back to 0.
            // A and D OR left and right arrows
            float moveHorizontal = Input.GetAxis("Horizontal");
            // gets input from the keyboard keys Up and Down OR W and S
            // only W is used.
            // -1 for S, +1 for W
            float moveVertical = Input.GetAxis("Vertical");

            // from the RigidBody2D, which stores variables regarding movement and physics
            // store the current velocity of the player so we can modify it
            // and later set the current velocity to this new modified target
            Vector2 targetVelocity = rb2D.velocity;

            // if the keyboard input gave us a value that is NOT 0,
            // as in, if a button was pressed on the horizontal axis
            if (moveVertical > 0 && rb2D.velocity.y == 0)
            {
                // get the audiosource component from the gameobject, and play the current clip.
                GetComponent<AudioSource>().Play();

                // set the x component of the target velocity to the keyboard input directions (from -1 to 1)
                // multiplied by the movement speed
                targetVelocity.y = m_jumpSpeed;
            }

            // if the player is pressing the jump button, moveVertical will go to +1, so if the player presses jump
            // and they are not either already jumping or falling
            if (moveHorizontal != 0)
                // set the vertical target velocity to the jump speed, which will make the object shoot upward
                targetVelocity.x = moveHorizontal * m_horizontalSpeed;

            // Finally, from the rigidbody, set the objects velocity to the new target velocity.
            rb2D.velocity = targetVelocity;
        }
    }

    // method that is called from coin to add points to the score and then display them on scoreText
    public void AddPoints(int pointValue)
    {
        // score is incremented by increasing it by pointValue
        score = score + pointValue;
        // sets the text part of the text object to display current score
        scoreText.text = "Score: " + score.ToString();
    }

    // called when the player starts to collide with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the collision was with a platform object
        if (collision.gameObject.tag == "Platform")
        {
            // parent the player to that platform.
            // this is to have the player move with the platform, because children move with their parents.
            transform.parent = collision.transform;
        }

        // if the collision was with an enemy object
        if (collision.gameObject.tag == "Enemy")
        {
            // enable the loseText so it is visible
            loseText.enabled = true;
            // set alive to false so that the player cannot process input
            alive = false;
        }
    }

    // called when the player stops colliding with another object
    private void OnCollisionExit2D(Collision2D collision)
    {
        // if the collision was with a platform object
        if (collision.gameObject.tag == "Platform")
        {
            // unparent the player from the platform. This will allow the player to move freely
            transform.parent = null;
        }
    }

}
