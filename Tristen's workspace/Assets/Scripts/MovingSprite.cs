using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSprite : MonoBehaviour
{

    //
    public float leftBoundry = 2f;
    public float rightboundry = 1f;

    // store starting position (x,y)
    private Vector2 startPosition;

    // true false which way are we moving?
    public bool movingLeft = true;



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

        // check if platform is moving left
        if(movingLeft == true)
        {
            // take where the platform is now (x,y) and change it so the platform moves left
            // 
            newPosition.x = transform.position.x - (1.0f * Time.fixedDeltaTime) ;
                // newPosition.x = transform.position.x -
        }
        else
        {
            // move neow position to the right
            newPosition.x = transform.position.x + (1.0f * Time.fixedDeltaTime);
        }

        // set the position of the sprite to our updated newPosition 
        GetComponent<Rigidbody2D>().MovePosition(newPosition);
       


    }
}
