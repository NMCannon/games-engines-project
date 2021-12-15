using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        // Resume time
        Time.timeScale = 1f;
        // Load game scene
        SceneManager.LoadScene("Game");
    }


    public void QuitGame()
    {
        Debug.Log("QUIT");
        // Close game
        Application.Quit();
    }

}
