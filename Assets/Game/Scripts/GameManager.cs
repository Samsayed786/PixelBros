using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        // Show the death screen and restart the level
        ShowDeathScreen();
    }

    private void ShowDeathScreen()
    {
        // Code to display the death screen
        // For example, enabling a UI panel
        // You can create a simple UI Canvas with a death message and a restart button
        Debug.Log("Player Died! Displaying death screen...");
    }

    public void RestartLevel()
    {
        // Restart the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
