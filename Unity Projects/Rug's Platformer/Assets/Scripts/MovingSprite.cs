using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSprite : MonoBehaviour
{
    public bool movingRight = true;
    // Start is called before the first frame update
    public float speed = 3.0f;
    //keep track of how far sprite can move
    public float distanceFromStart = 2.0f;
    //keep track of start posotion
    private Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Start is called before the first frame update
    void FixedUpdate()
    {
        Vector2 newPos = transform.position;
        if (movingRight == true)
        {
            newPos.x = transform.position.x + speed * Time.fixedDeltaTime;
            if (newPos.x > startPos.x + distanceFromStart)
            {
                movingRight = false;
            }
        }
        else if (movingRight == false)
        {
            newPos.x = transform.position.x - speed * Time.fixedDeltaTime;
            if (newPos.x < startPos.x - distanceFromStart)
            {
                movingRight = true;
            }
            
        }
        GetComponent<Rigidbody2D>().MovePosition(newPos);
    }
}



