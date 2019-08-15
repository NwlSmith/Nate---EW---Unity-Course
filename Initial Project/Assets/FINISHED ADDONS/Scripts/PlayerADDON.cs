using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerADDON : MonoBehaviour
{
    // ADD TO PLAYER PREFAB
    // Used to restart level if player dies.
    // Comes in 2 versions:
    // 1. Simple (default): if player dies, restart.
    // 2. With Canvas: If canvas is present, have losetext appear and player must press 'R' to restart

    public bool simpleRestart = true;
    private Text winText;
    private Text loseText;

    private void Start()
    {
        MonoBehaviour[] monoBehaviours = GetComponents<MonoBehaviour>();
        bool found = false;
        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            if (monoBehaviour.GetType().Name == "Player")
                found = true;
        }

        if (!found)
        {
            Debug.Log("ERROR: PlayerADDON Component placed on GameObject without Player Script, OR Player Script named incorrectly, must be named EXACTLY 'Player'.");
        }

        Text[] texts = FindObjectsOfType<Text>();
        foreach (Text text in texts)
        {
            if (text.name == "WinText")
            {
                winText = text;
                winText.enabled = false;
            }
            if (text.name == "LoseText")
            {
                loseText = text;
                loseText.enabled = false;
            }
        }
        if (loseText == null || winText == null)
        {
            simpleRestart = true;
            Debug.Log("ERROR: GameCanvas is not present in the scene.");
        }
    }

    private void Update()
    {
        if (simpleRestart || loseText.enabled || winText.enabled)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (simpleRestart)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else
                loseText.enabled = true;
        }
    }

    public void WinGame()
    {
        if (simpleRestart)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            winText.enabled = true;
    }
}