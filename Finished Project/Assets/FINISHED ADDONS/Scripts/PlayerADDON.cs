using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerADDON : MonoBehaviour
{
    // ADD TO PLAYER PREFAB

    private Text loseText;

    private void Start()
    {
        Text[] texts = FindObjectsOfType<Text>();
        foreach (Text text in texts)
        {
            if (text.name == "LoseText")
            {
                loseText = text;
                loseText.enabled = false;
            }
        }
        if (loseText == null)
        {
            Debug.Log("ERROR: GameCanvas is not present in the scene.");
        }

        if (!GetComponent<Player>())
        {
            Debug.Log("ERROR: PlayerADDON Component placed on GameObject without Player Script.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            loseText.enabled = true;
        }
    }


}
