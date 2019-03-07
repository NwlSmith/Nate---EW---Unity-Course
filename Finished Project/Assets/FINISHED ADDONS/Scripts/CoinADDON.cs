using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinADDON : MonoBehaviour
{
    // ADD TO COIN PREFAB
    private int pointValue;
    private Text scoreText;
    private ScoreADDON scoreADDON;

    private void Start()
    {
        pointValue = GetComponent<Coin>().pointValue;
        Text[] texts = FindObjectsOfType<Text>();
        scoreADDON = FindObjectOfType<ScoreADDON>();
        scoreText = scoreADDON.GetComponent<Text>();
        if (scoreText == null)
        {
            Debug.Log("ERROR: GameCanvas is not present in the scene.");
        }
        

        if (!GetComponent<Coin>())
        {
            Debug.Log("ERROR: CoinADDON Component placed on GameObject without Coin Script.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            scoreADDON.score += pointValue;
            scoreText.text = "Score: " + scoreADDON.score.ToString();
        }
    }
}
