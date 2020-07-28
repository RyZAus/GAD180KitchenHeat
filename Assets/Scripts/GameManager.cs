using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public GameObject[] ingredientsToSpawn;
    public Transform[] spawnLocs;
    List<Transform> activeSpawnLocs = new List<Transform>();
    public int score;
    public float timer;
    public Text scoreText;
    public Text timerText;
    public Text resultsText;
    public bool GameIsPaused = false;
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverScreen;
    public GameObject welcomeMessage;
    private int ingredients = 2; // the number of ingredient to spawn on the first recipe
   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 300;
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + timer;
       
    }

    int NextLevel()
    {
        ingredients = ingredients++;
        return ingredients;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + timer.ToString("0.00");
        if (Input.GetKeyDown(KeyCode.Q))
      {
            RepopSpawnLocs(); //Fill our list with our locations
            RandomSpawn(); //Spawn objects and delete each location from the list  
      }
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
            resultsText.text = "You finished with a score of " + score;
        }
        if (timer < 295)
		{
            welcomeMessage.SetActive(false);
		}
               }
     public void RepopSpawnLocs()
    {
        for(int i = 0; i < spawnLocs.Length; i++)
        {
            activeSpawnLocs.Add(spawnLocs[i]); //adding array item, to a list
        }
    }
    public void RandomSpawn()
    {
        for(int i = 0; i < ingredientsToSpawn.Length; i++)
        {
            //use our list here
            int x = Random.Range(0, activeSpawnLocs.Count);
            Instantiate(ingredientsToSpawn[i], activeSpawnLocs[x]);
            activeSpawnLocs.RemoveAt(x);
        }
    }
    int scoreUpdate()
    {
        score = score++;
        return score;
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
