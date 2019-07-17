using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreADDON : MonoBehaviour
{
    // ALREADY ON PREFAB
    // Handles score text

    public int score = 0;
    public bool winIfCollectAllCoins = false;
    private int numCoins = 0;

    private void Start()
    {
        if (winIfCollectAllCoins)
        {
            numCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        if (winIfCollectAllCoins)
        {
            numCoins--;
            if (numCoins <= 0)
            {
                FindObjectOfType<PlayerADDON>().WinGame();
            }
        }
    }
}
