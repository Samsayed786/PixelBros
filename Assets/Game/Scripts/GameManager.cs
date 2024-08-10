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

    private void Update()
    {
        HandleCursorLock();
    }

    private void HandleCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void PlayerDied()
    {
        // Show the death screen
        ShowDeathScreen();
    }

    private void ShowDeathScreen()
    {
        deathScreenUI.SetActive(true);
        Debug.Log("Player Died! Displaying death screen...");

        // Unlock the cursor and make it visible when the death screen is shown
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartLevel()
    {
        //SceneManager.LoadScene("LevelName");
        HideMainMenu();

        // Lock the cursor and hide it when the level starts
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("Start Level button pressed. Loading Level1...");
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
