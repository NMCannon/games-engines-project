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
        scoreText = GetComponent<Text>();
    }


    public void AddPoint()
    {
        scoreValue += 1;
        scoreText.text = "SCORE: " + scoreValue;

        if (scoreValue >= 20)
        {
            FindObjectOfType<AudioManager>().Play("PlayerWin");
            winMenu.Setup();
        }
    }
}
