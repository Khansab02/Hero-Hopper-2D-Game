using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    private void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    public void load()
    {
       
        SceneManager.LoadScene("Game");

    }
   

}
