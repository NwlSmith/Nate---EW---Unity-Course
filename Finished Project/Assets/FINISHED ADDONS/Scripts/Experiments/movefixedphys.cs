using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefixedphys : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.position = new Vector2(rb.position.x + .01f, rb.position.y);
    }
}
