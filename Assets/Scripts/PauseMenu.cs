using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Runtime.InteropServices;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject inGameUI;
    

    // Update is called once per frame
    void Update()
    {     
      if (Input.GetKeyDown(KeyCode.Escape))
      {
          Pause();
      }
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        inGameUI.SetActive(true);
        print("The game is not paused");
    }
    public void Pause()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        print("The game is paused");
    }
    public void OptionMenu()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        print("Loading Options...");
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        print("Quitting to Main Menu...");
        SceneManager.LoadScene(0);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        print("The current volume is " + volume);
        
    }
}
