using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("µã»÷ÒôÐ§")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    public void StartGame()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            Invoke("LoadLevel", 0.2f);
        }
        else
        {
            LoadLevel();
        }
  
    }
    void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }

}
