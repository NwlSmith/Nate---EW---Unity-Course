using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObjectAddon : MonoBehaviour
{

    // ALREADY ON PREFAB
    // Handles win object functionality

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            FindObjectOfType<PlayerADDON>().WinGame();
    }
}
