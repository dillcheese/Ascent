using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button restartButton;

    private bool isPaused = false;

    private void Start()
    {
        // Add listeners to the buttons
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);

        // Hide the pause menu
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Replace 'P' with the key you want to use to pause the game
        {
            if (isPaused)
            {
                // Unpause the game
                ResumeGame();
            }
            else
            {
                // Pause the game
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;

        // Show the pause menu
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;

        // Hide the pause menu
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1;
        isPaused = false;

        // Hide the pause menu
        pauseMenu.SetActive(false);
    }
}