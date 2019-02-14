using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float m_horizontalSpeed = 10f;
    public float m_jumpSpeed = 10f;

    public int score = 0;

    public ScoreSetter scoreSetter;
    public Text loseText;

    private bool alive = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        loseText.enabled = false;
    }

    private void FixedUpdate()
    {
        if (alive)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 targetVelocity = rb.velocity;

            if (moveVertical > 0 && rb.velocity.y == 0)
            {
                //Play sound
                targetVelocity.y = m_jumpSpeed;
            }

            if (moveHorizontal != 0)
                targetVelocity.x = moveHorizontal * m_horizontalSpeed;

            rb.velocity = targetVelocity;
        }
    }

    public void AddPoints(int pointValue)
    {
        score += pointValue;
        scoreSetter.SetScore(score);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit enemy");
            loseText.enabled = true;
            alive = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }

}
