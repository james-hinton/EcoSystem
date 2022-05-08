using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FoodObject;

public class SpawnFood : MonoBehaviour
{
    // For objects tagged "Ground"
    public GameObject[] foodSourceObjects;

    public GameObject prefab;

    // Function to spawn the food within bounds
    public void Spawn(string foodType)
    {   
        if (foodType == "Apple")
        {
            foodSourceObjects = GameObject.FindGameObjectsWithTag("Tree");
        }

        // Get a random object
        int FoodSourceObject = Random.Range(0, foodSourceObjects.Length);
        
        // Vector3 position of the food source object
        Vector3 position = foodSourceObjects[FoodSourceObject].transform.position;

        /* Spawn the food */
        // Create new FoodObject object
        FoodObject foodObject = new FoodObject();

        // Randomise the position by five times the size of the prefab
        position.x += Random.Range(-prefab.transform.localScale.x * 5, prefab.transform.localScale.x * 5);
        // position.y += Random.Range(-prefab.transform.localScale.y * 5, prefab.transform.localScale.y * 5);
        position.z += Random.Range(-prefab.transform.localScale.z * 5, prefab.transform.localScale.z * 5);

        // Spawn the food
        foodObject.Spawn(prefab, position);
    }

}
