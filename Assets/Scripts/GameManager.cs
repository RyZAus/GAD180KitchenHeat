using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] ingredientsToSpawn;
    public Transform[] spawnLocs;
    List<Transform> activeSpawnLocs = new List<Transform>();
    private int score;
    private int ingredients = 2; // the number of ingredient to spawn on the first recipe
   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
       
    }

    int NextLevel()
    {
        ingredients = ingredients++;
        return ingredients;
    }

    // Update is called once per frame
    void Update()
    {
        
      if (Input.GetKeyDown(KeyCode.Space))
        {
            RepopSpawnLocs(); //Fill our list with our locations
            RandomSpawn(); //Spawn objects and delete each location from the list  
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
    

   
}
