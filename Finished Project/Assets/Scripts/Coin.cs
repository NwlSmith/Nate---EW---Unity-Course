using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int pointValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // add sound
            collision.GetComponent<Player>().AddPoints(pointValue);
            Destroy(gameObject);
        }
    }

}
