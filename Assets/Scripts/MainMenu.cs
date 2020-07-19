using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject tutorialMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        print("Game has been closed");
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        print("The current volume is " + volume);
        audioMixer.SetFloat("volume", volume);
    }
    public void ReturnMenu()
    {
        mainMenu.gameObject.SetActive(true);
        optionMenu.gameObject.SetActive(false);
        tutorialMenu.gameObject.SetActive(false);
    }
    public void OptionScreen()
    {
        mainMenu.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(true);
        tutorialMenu.gameObject.SetActive(false);
    }
    public void HowToPlay()
    {
        mainMenu.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(false);
        tutorialMenu.gameObject.SetActive(true);
    }
}




