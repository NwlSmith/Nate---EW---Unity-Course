using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSprite : MonoBehaviour
{
    public bool movingRight = true;
    // keep track of speed
    public float speed = 3.0f;
    // kep track of how far sprite can move
    public float distanceFromStart = 2.0f;
    // keep track of start position
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        //move to the right
        Vector2 newPosition = transform.position;
        // check if moving rihgt
        if (movingRight == true)
        {
            // move to the right
            newPosition.x = transform.position.x + speed * Time.fixedDeltaTime;
            // if too far to the right
            if (newPosition.x > startPosition.x + distanceFromStart)
            {

                // start moving left
                movingRight = false;
            }

        }
        else // if moving left
        {
            // move to the left
            newPosition.x = transform.position.x - speed * Time.fixedDeltaTime;

            if (newPosition.x < startPosition.x - distanceFromStart)
            {
                movingRight = true;
            }
        }
        // set new position
        GetComponent<Rigidbody2D>().MovePosition(newPosition);

    }
}


