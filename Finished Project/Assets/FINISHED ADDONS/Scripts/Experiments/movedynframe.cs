using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedynframe : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.position = new Vector2(rb.position.x + Time.deltaTime, rb.position.y);
    }
}
