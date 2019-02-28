using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // variable to store the point value of coin that will be given to the player when they pick it up
    public int pointValue = 1;

    // this triggers when the gameobject collides with anything else that has a collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // this has the progression that shows when each bit of code is added.

        // v2 check to see if player has collided with the coin
        if (collision.tag == "Player")
        {
            // no score yet, it should disappear when collided with player
            // well... this should only be called if the player touches it

            // v1 destory game object when something collides with it
            // Destroy(gameObject);


            // v3 add sounds

            // Destroy(gameObject);
            // GetComponent<AudioSource>().Play();

            // did it work? No because it is destroyed before the sound can play
            // reorder

            // v3.5
            // GetComponent<AudioSource>().Play();
            // Destroy(gameObject);

            // did it work? No because even though the sound plays first, the sprite is destroyed too quickly 
            // add delay to destroy

            // v4
            // GetComponent<AudioSource>().Play();
            // Destroy(gameObject,4f); // long delay for teaching purposes

            // does it work now? Yes, the sound plays and then the sprite is destroyed
            // how could we make it better? - hide sprite as soon as the player collides with it

            // v5
            // final coin sound script
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.2f);


        }
    }

}