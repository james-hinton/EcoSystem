using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static SpawnFood;

public class Main : MonoBehaviour
{
    // Food prefab
    public GameObject foodPrefab;

    public GameObject animalPrefab;

    // setSpawnFood is called when the spawn button is clicked
    public void setSpawnFood()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnFood spawnFood = new SpawnFood();

            // Set the prefab
            spawnFood.prefab = foodPrefab;

            // Spawn the food
            spawnFood.Spawn("Apple");
        }

    }

    public void setSpawnAnimal()
    {
        SpawnAnimal spawnAnimal = new SpawnAnimal();

        // Set the prefab
        spawnAnimal.prefab = animalPrefab;

        // Spawn the animal
        spawnAnimal.Spawn();
    }

    // Start is called before the first frame update
    void Start()
    {

        setSpawnFood();
        

        // Ivoke Repeating every 5 seconds setSpawnFood and set parameters to 10
        InvokeRepeating("setSpawnFood", 0, 5);
    }

}
