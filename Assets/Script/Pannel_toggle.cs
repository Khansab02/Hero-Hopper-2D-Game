using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelToggle : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Reference to the pause menu panel
    private bool isPaused =false; // Track whether the game is paused
    public Text text;

    private void Update()
    {
      
        
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuPanel.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Pause the game
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume the game
    }

    public void QuitGame()
    {
        // This will quit the application
        Application.Quit();
        Debug.Log("Game is quitting..."); // Log for debugging purposes
    }
}