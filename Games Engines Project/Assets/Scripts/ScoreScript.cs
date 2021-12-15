using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    Text scoreText;
    public int scoreValue;

    public WinMenu winMenu;

    void Start()
    {
        // Get text component
        scoreText = GetComponent<Text>();
    }


    public void AddPoint()
    {
        // Add 1 to score
        scoreValue += 1;
        // Update UI
        scoreText.text = "SCORE: " + scoreValue;

        // If score over 20
        if (scoreValue >= 20)
        {
            // Play win audio
            FindObjectOfType<AudioManager>().Play("PlayerWin");
            // Show win menu
            winMenu.Setup();
        }
    }
}
