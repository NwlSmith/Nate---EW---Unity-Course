using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 1f);
        }
    }
}
