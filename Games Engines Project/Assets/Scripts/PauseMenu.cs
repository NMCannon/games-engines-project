using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameOverUI;

    // Update is called once per frame
    public void Update()
    {
        // If game over menu isn't active
        if (!gameOverUI.activeSelf)
        {
            // If escape key is pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // If the game is already paused, resume game
                if (GameIsPaused)
                {
                    Resume();
                }
                // Else pause game
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        // Hide menu
        pauseMenuUI.SetActive(false);
        // Resume time
        Time.timeScale = 1f;
        GameIsPaused = false;
        // Lock cursor to screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        // Show menu
        pauseMenuUI.SetActive(true);
        // Stop time
        Time.timeScale = 0f;
        GameIsPaused = true;
        // Free the cursor
        Cursor.lockState = CursorLockMode.None;
    }

    public void GoToMenu()
    {
        // Load main menu scene
        SceneManager.LoadScene("Menu");
    }
}
