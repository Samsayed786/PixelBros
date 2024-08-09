using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject deathScreenUI; // Reference to the death screen UI Canvas or Panel

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
}
