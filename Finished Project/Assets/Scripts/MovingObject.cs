using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    // How far to the left the platform can travel from the starting position.
    public float leftBoundary = 3f;
    // How far to the right the platform can travel from the starting position.
    public float rightBoundary = 3f;

    // How fast the platform will move.
    public float speed = 3f;

    // A boolean that says if the platform is currently moving left (movingLeft = true), or right (movingLeft = false)
    public bool movingLeft;

    // The position that the platform is when the game starts.
    private Vector2 startPos;

    // Called before the first frame of the game.
    private void Start() 
    {
        // Set startPos to the initial position of the platform
        startPos = transform.position; 
    }

    //  Called every PHYSICS frame of the game.
    private void FixedUpdate() 
    {
        // Create a Vector2. This Vector2 will be used to set the NEW position of the platform at the end of the physics frame.
        // Because some parts of the position (X or Y) of the platform will not change, initially set the new position to the current position.
        Vector2 newPosition = transform.position; //  ask how you would do that?

        // if the platform is moving left...
        if (movingLeft) 
        {
            // Set the new x position of the platform to the the current x position of the platform,
            // but moved to the LEFT by an amount based off of the speed of the platform and the amount of time that has passed since FixedUpdate was last called.
            newPosition.x = transform.position.x - ( speed * Time.fixedDeltaTime );
            // if the new position will place the platform to the left of the left-side boundary...
            if (newPosition.x <= startPos.x - leftBoundary) 
            {
                // make it move Right on the next FixedUpdate by saying the the platform is NOT moving left
                movingLeft = false; 
            }
        }
        // if movingLeft is false, ie, if moving RIGHT
        else
        {
            // Set the new x position of the platform to the the current x position of the platform,
            // but moved to the RIGHT by an amount based off of the speed of the platform and the amount of time that has passed since FixedUpdate was last called.
            newPosition.x = transform.position.x + (speed * Time.fixedDeltaTime);
            // if the new position will place the platform to the RIGHT of the RIGHT-side boundary...
            if (newPosition.x >= startPos.x + rightBoundary)
            {
                // make it move LEFT on the next FixedUpdate by saying the the platform IS moving left
                movingLeft = true; 
            }
        }

        GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }


}
