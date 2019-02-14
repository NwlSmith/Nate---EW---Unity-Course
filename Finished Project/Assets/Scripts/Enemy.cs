using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float leftBoundary = 2f;
    public float rightBoundary = 2f;

    public float speed = 1f;

    public bool movingLeft;

    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = transform.position;
        if (movingLeft)
        {
            newPosition.x = transform.position.x - ( speed * Time.fixedDeltaTime );
            if (newPosition.x <= startPos.x - leftBoundary)
            {
                movingLeft = false;
            }
        }
        else // if movingLeft is false, ie, if moving RIGHT
        {
            newPosition.x = transform.position.x + (speed * Time.fixedDeltaTime);
            if (newPosition.x >= startPos.x + rightBoundary)
            {
                movingLeft = true;
            }
        }

        GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }
}
