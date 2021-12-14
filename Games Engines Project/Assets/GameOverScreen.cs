using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public void Setup()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        // Load current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
