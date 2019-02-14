using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour {

    private void Awake()
    {
        
    }

    public void SetScore(int score)
    {
        GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
