using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSprite : MonoBehaviour
{
    // store the boundaries of the platform
    public float distanceFromStart = 2f;

    // keep track of if the sprite is moving right or left
    public bool movingRight = true;

    // the speed at which the sprite will move
    public float speed = 3f;

    // store the start position of the vector
    private Vector2 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        // store this start position by taking the current position from the transform component of game object
        startPosition = transform.position;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // create an variable to store what will be the the new position, from the current position
        Vector2 newPosition = transform.position;

        //CHANGE THIS
        // if movingRight == true, ie, if movingRight != false, ie, if moving right
        if (movingRight == true)
        {
            //move new position to the right by speed
            newPosition.x = transform.position.x + speed * Time.fixedDeltaTime;
            // if the newPosition.x is to the right of distanceFromStart, ie, out of bounds
            if (newPosition.x > startPosition.x + distanceFromStart)
            {
                // move left
                movingRight = false;
            }
        }
        // if the platform is moving left - expand here
        else
        {
            // move new position to the left by speed
            newPosition.x = transform.position.x - speed * Time.fixedDeltaTime;
            // if the newPosition.x is to the left of distanceFromStart, ie, out of bounds
            if (newPosition.x < startPosition.x - distanceFromStart)
            {
                // make it move right
                movingRight = true;
            }
        }

        //use the rigidbody2d to set the current position to the updated new position
        GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }
}
