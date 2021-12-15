using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{

    public void Setup()
    {
        // Stop time
        Time.timeScale = 0f;
        // Show menu
        gameObject.SetActive(true);
        // Free the cursor
        Cursor.lockState = CursorLockMode.None;
    }

    public void GoToMenu()
    {
        // Load main menu scene
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        // Close game
        Application.Quit();
    }
}
