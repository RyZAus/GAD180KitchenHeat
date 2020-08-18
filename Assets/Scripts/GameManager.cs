using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Net;

public class GameManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem = null;
    [SerializeField] ParticleSystem badparticles = null;

    public GameObject[] ingredientsToSpawn;
    public Transform[] spawnLocs;
    public Sprite[] spriteArray;
    List<Transform> activeSpawnLocs = new List<Transform>();
    public int score;
    public float timer;
    public Text scoreText;
    public Text timerText;
    public Text resultsText;
    public Text highScoreText;
    public bool GameIsPaused = false;

    public AudioMixer audioMixer;
    public AudioSource gameMusic;
    public AudioSource gameOverClip;
    public AudioSource goodIngredient;
    public AudioSource badIngredient;
    
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverScreen;
    public GameObject welcomeMessage;
    private int ingredients = 2; // the number of ingredient to spawn on the first recipe
    public List<GameObject> recipe = new List<GameObject>();
    public int multiplier = 1;
    SpriteRenderer object1Renderer;
    SpriteRenderer object2Renderer;
    SpriteRenderer object3Renderer;
    SpriteRenderer object4Renderer;
    int ing1 = 0;
    int ing2 = 0;
    int ing3 = 0;
    int ing4 = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 90;
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + timer;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        CreateRecipe();
        particleSystem.Stop();
        badparticles.Stop();
        object1Renderer = GameObject.Find("Ingredient Space 1").GetComponent<SpriteRenderer>();
        object2Renderer = GameObject.Find("Ingredient Space 2").GetComponent<SpriteRenderer>();
        object3Renderer = GameObject.Find("Ingredient Space 3").GetComponent<SpriteRenderer>();
        object4Renderer = GameObject.Find("Ingredient Space 4").GetComponent<SpriteRenderer>();

        RepopSpawnLocs();
        RandomSpawn();
    }

    void CreateRecipe()
    {
        ing1 = Random.Range(0,3);
        ing2 = Random.Range(3,7);
        ing3 = Random.Range(7,10);
        ing4 = Random.Range(10,13);
        recipe.Add(ingredientsToSpawn[ing1]);
        recipe.Add(ingredientsToSpawn[ing2]);
        recipe.Add(ingredientsToSpawn[ing3]);
        recipe.Add(ingredientsToSpawn[ing4]);
        
    }

    public void RemoveIngredients(GameObject ingredient)
    {
        bool wasFound = false;

        foreach(GameObject i in recipe)
		{
            if (i.GetComponent<Ingredient>().thisIngredient == ingredient.GetComponent<Ingredient>().thisIngredient)
			{
                wasFound = true;
			}

        }

        if (wasFound)
        {
            if (recipe.Count != 0)
            {
                foreach (GameObject go in recipe)
                {
                    if (go.GetComponent<Ingredient>().thisIngredient == ingredient.GetComponent<Ingredient>().thisIngredient)
                    {
                        recipe.Remove(go);
                        particleSystem.Play();
                        scoreUpdate();
                        multiplierUpdate();
                        //good ingredient audio
                        goodIngredient.Play();
                    }

                }
            }
        }
        else
		{
            badparticles.Play();
            multiplier = 1;
            //bad ingredient audio clip
            badIngredient.Play();

        }
    }
    public void CheckScoreUpdate(GameObject ingredient)
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //DEVELOPER TOOLS TO REMOVE LATER
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredient");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Destroy(ingredients[i]);
            }
            RepopSpawnLocs();
            RandomSpawn();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RepopSpawnLocs(); //Fill our list with our locations
            RandomSpawn(); //Spawn objects and delete each location from the list  
        }



        //if statement to identify which of the ingredients is being removed to then set eg. object1Renderer.sprite = spriteArray[13] which will set the sprite to clear
        object1Renderer.sprite = spriteArray[ing1];
        object2Renderer.sprite = spriteArray[ing2];
        object3Renderer.sprite = spriteArray[ing3];
        object4Renderer.sprite = spriteArray[ing4];
        if (recipe.Count == 0)
        {
            CreateRecipe();
            //provides additional point for completing a recipe > this can be replaced if needed once we figure out what will happen with score bonuses
            scoreUpdate();
            GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredient");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Destroy(ingredients[i]);
            }
            RepopSpawnLocs();
            RandomSpawn();
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        scoreText.text = "Score: " + score.ToString();
        timerText.text = "Time: " + timer.ToString("0.00");
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
            timerText.text = "";
            gameOverScreen.SetActive(true);
            resultsText.text = "You finished with a score of " + score;
            Time.timeScale = 0f;
            GameOverState();
        }
        if (timer < 85)
        {
            welcomeMessage.SetActive(false);
        }
    }

    public void GameOverState()
	{
        gameMusic.Stop();
        //gameover clip to play
        gameOverClip.Play();
    }
    public void RepopSpawnLocs()
    {
        for (int i = 0; i < spawnLocs.Length; i++)
        {
            activeSpawnLocs.Add(spawnLocs[i]); //adding array item, to a list
        }
    }
    public void RandomSpawn()
    {
        for (int i = 0; i < ingredientsToSpawn.Length; i++)
        {
            //use our list here
            int x = Random.Range(0, activeSpawnLocs.Count);
            Instantiate(ingredientsToSpawn[i], activeSpawnLocs[x]);
            activeSpawnLocs.RemoveAt(x);
        }
    }

   
            
    public void scoreUpdate()
    {
        score = score + (25 * multiplier);
        if (score > PlayerPrefs.GetInt("HighScore",0))
		{
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
		}
        
    }

    public void multiplierUpdate()
	{
        multiplier = multiplier + 1;
	}

    public void scoreUpdateMinus()
    {
        score = score - 1;
    }

    public void HighScoreReset()
	{
        PlayerPrefs.DeleteKey("HighScore");
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
