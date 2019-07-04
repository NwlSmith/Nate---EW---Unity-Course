using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperhotMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    private Rigidbody2D rb2D;

    private void Start()
    {
        maxSpeed = Mathf.Sqrt(Mathf.Pow(maxSpeed, 2) + Mathf.Pow(maxSpeed, 2));
        rb2D = GetComponent<Rigidbody2D>();
        // get player speed here
    }


    private void FixedUpdate()
    {
        float fract = Mathf.Sqrt(Mathf.Pow(rb2D.velocity.x, 2) + Mathf.Pow(rb2D.velocity.y, 2)) / maxSpeed;
        Time.timeScale = Mathf.Max(fract, .1f);
    }
}
