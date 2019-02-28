using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSprite2 : MonoBehaviour
{

    // Global Varables
    public float moveDistance = 2f;
    public float speed = 10f;

    // store starting position (x,y)
    private Vector2 startPosition;



    // Start is called before the first frame update
    void Start()
    {
        // store the start position from transform
        startPosition = transform.position;



    }

    // FixedUpdate is called once per physcis frame
    void FixedUpdate()
    {
        // create a variable to store new position
        Vector2 newPosition = transform.position;

        // if the new position.x is left of the leftBoundry, then start moving right
        if (newPosition.x < startPosition.x - moveDistance)
        {
            speed = speed * -1;
        }

        // if newPositino.x is to the right of rightBoundry, then move left
        if (newPosition.x > startPosition.x + moveDistance)
        {
            // move left
            speed = speed * -1;
        }

        // take where the platform is now (x,y) and change it so the platform moves left
        //  new position.x = where you are - (speed * small number)
        newPosition.x = transform.position.x + (speed * Time.fixedDeltaTime);

        // set the position of the sprite to our updated newPosition 
        GetComponent<Rigidbody2D>().MovePosition(newPosition);



    }
}
