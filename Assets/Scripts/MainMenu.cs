using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Text highScoreText;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject tutorialMenu;
    public GameObject controlButtons;
    

    void Update()
	{
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void HighScoreReset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

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
        audioMixer.SetFloat("volume", volume);
    }
    public void ReturnMenu()
    {
        mainMenu.gameObject.SetActive(true);
        optionMenu.gameObject.SetActive(false);
        tutorialMenu.gameObject.SetActive(false);
        controlButtons.gameObject.SetActive(false);
    }
    public void OptionScreen()
    {
        mainMenu.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(true);
        tutorialMenu.gameObject.SetActive(false);
        controlButtons.gameObject.SetActive(true);
    }
    public void HowToPlay()
    {
        mainMenu.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(false);
        tutorialMenu.gameObject.SetActive(true);
        controlButtons.gameObject.SetActive(false);
    }
}




