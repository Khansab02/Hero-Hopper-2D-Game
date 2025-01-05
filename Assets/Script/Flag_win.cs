using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Flag_win : MonoBehaviour
{
    public GameObject pauseMenuPanel; 
    private bool isPaused = false;
    public Text text;
  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPaused = true;
            pauseMenuPanel.SetActive(true); // Show the pause menu
            StartCoroutine(time());
            SceneManager.LoadScene("Menu");

            
            Time.timeScale = 0f; // Pause the game
        }
    }
    IEnumerator time()
    {
        yield return new WaitForSeconds(5f);
    }    
}
