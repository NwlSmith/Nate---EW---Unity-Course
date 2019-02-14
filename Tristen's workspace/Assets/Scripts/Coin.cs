using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // variable to store value of point when coin is collected
    public int pointValue = 1;

    // this triggers when the sprite collides with enything else that has a ridgid body
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // pt2 check to see if player has collided with the coin
        if (collision.tag == "Player")
        {
            // no score yet, it should disappear when collided with player
            // well... this should only be called if the player touches it

            // v1 destory game object when the player collides with it
            // Destroy(gameObject);


            // v2 add sounds

            // Destroy(gameObject);
            // GetComponent<AudioSource>().Play();

            // did it work? No because it is destoryed before the sound can play
            // reorder

            // GetComponent<AudioSource>().Play();
            // Destroy(gameObject);

            // did it work? No because even though the sound plays first, the sprite is destoryed too quickly 
            // add delay to destory

            // GetComponent<AudioSource>().Play();
            // Destroy(gameObject,4f); // long delay for teaching purposes

            // does it work now? Yes, the sound plays and then the sprite is destoryed
            // how could we make it better? - hide sprite as soon as the playr collides with it


            // final coin sound script
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject,0.2f); // long delay for teaching purposes


        }
    }


    
        
    


}
