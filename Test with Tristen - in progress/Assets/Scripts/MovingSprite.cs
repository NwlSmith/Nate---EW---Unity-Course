using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSprite : MonoBehaviour
{
    // store the boundaries of the platform
    public float leftBoundary = 2f;
    public float rightBoundary = 1f;

    // keep track of if the sprite is moving right or left
    public bool movingLeft = true;

    // store the start position of the vector
    private Vector2 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        // store start position from position part of transform component of game object
        startPosition = transform.position;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // create an variable to store what will be the the new position, from the current position
        Vector2 newPosition = transform.position;

        // if the platform is moving left
        if (movingLeft == true)
        {
            // move new position to the left
            newPosition.x = transform.position.x - 1f * Time.fixedDeltaTime;
        }
        // if movingLeft == false, ie, if movingLeft != true, ie, if moving right
        else
        {
            //move new position to the right
            newPosition.x = transform.position.x + 1f * Time.fixedDeltaTime;
        }

        //use the rigidbody2d to set the current position to the updated new position
        GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }
}
