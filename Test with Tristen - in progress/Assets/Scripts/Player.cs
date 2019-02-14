using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool alive = true;

    public float horizontalSpeed = 10.0f;
    public float jumpSpeed = 10.0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per physics frame
    void FixedUpdate()
    {
        if (alive == true)
        {
            float moveHorizonal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 targetVelocity = rb.velocity;

            if (moveHorizonal != 0)
            {
                targetVelocity.x = moveHorizonal * horizontalSpeed;
            }

            if (moveVertical > 0 && rb.velocity.y == 0)
            {
                targetVelocity.y = jumpSpeed;
            }

            rb.velocity = targetVelocity;
        }
    }
}
