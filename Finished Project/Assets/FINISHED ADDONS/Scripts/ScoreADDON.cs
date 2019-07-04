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
            Debug.Log("numcoins " + numCoins);
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Addpoints");
        if (winIfCollectAllCoins)
        {
            Debug.Log("numcoins before " + numCoins);
            numCoins--;
            Debug.Log("numcoins after " + numCoins);
            if (numCoins <= 0)
            {
                Debug.Log("zerocoins");
                FindObjectOfType<PlayerADDON>().WinGame();
            }
        }
    }
}
