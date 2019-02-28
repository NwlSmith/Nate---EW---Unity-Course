using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    // Global Variable
    // go over what a variable is
    // stores a little bit of code that either says "yes", this is alive, or "no", this is not alive.
    // public bool alive = true;

    // this is a reference to the rigidbody of our sprite
    // it contains variables for moving the gameobject, like velocity and force
    // we can modify these values to move our player
    private Rigidbody2D rb2D;

    // variable to store horizontal speed of player
    // because it is public, you will be able to change it from the inspector.
    // the player will move this many units per second.
    public float horizontalSpeed = 10.0f;

    // variable to store vertical speed of the player
    // the player will have their vertical velocity set to this value when jumping
    public float jumpSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // get and store the rigid body 2d from this game object so we can change it
        rb2D = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // if the player is still alive, allow input
        // get input from the keyboard keys and store in float variable from -1 to 1
        // -1 for left, +1 for right
        // when there is no input, this value will go back to 0.
        // A and D OR left and right arrows
        float moveHorizonal = Input.GetAxis("Horizontal");
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
        if (moveHorizonal != 0)
        {
            // set the x component of the target velocity to the keyboard input directions (from -1 to 1)
            // multiplied by the movement speed
            targetVelocity.x = moveHorizonal * horizontalSpeed;
        }

        // if the player is pressing the jump button, moveVertical will go to +1, so if the player presses jump
        // and they are not either already jumping or falling
        if (moveVertical > 0 && rb2D.velocity.y == 0)
        {
            // set the vertical target velocity to the jump speed, which will make the object shoot upward
            targetVelocity.y = jumpSpeed;
        }

        // Finally, from the rigidbody, set the objects velocity to the new target velocity.
        rb2D.velocity = targetVelocity;

    }
}
