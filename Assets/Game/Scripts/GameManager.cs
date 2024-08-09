using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject deathScreenUI; // Reference to the death screen UI Canvas or Panel
    public GameObject mainMenuPanel; // Reference to the Main Menu Panel

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Show the main menu on start
            ShowMainMenu();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        // Show the death screen
        ShowDeathScreen();
    }

    private void ShowDeathScreen()
    {
        deathScreenUI.SetActive(true); // Show the death screen UI
        Debug.Log("Player Died! Displaying death screen...");
    }

    public void RestartLevel()
    {
        // Restart the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartLevel()
    {
        // Load the level "Level1" when the start button is pressed
        SceneManager.LoadScene("Level1");
        HideMainMenu(); // Hide the main menu when the game starts
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    public void ShowMainMenu()
    {
        // Show the Main Menu Panel
        mainMenuPanel.SetActive(true);
    }

    public void HideMainMenu()
    {
        // Hide the Main Menu Panel
        mainMenuPanel.SetActive(false);
    }
}
