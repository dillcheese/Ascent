using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        // Add listeners to the buttons
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void PlayGame()
    {
        // Load the game scene (replace "GameScene" with the name of your game scene)
        SceneManager.LoadScene("Game");
    }

    private void ExitGame()
    {
        // Quit the game
        Application.Quit();
    }
}