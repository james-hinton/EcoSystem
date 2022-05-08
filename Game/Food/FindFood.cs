using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFood : MonoBehaviour
{
    // Function that finds nearest food
    public GameObject FindNearestFood(string[] foodPreferences, float range, Vector3 position)
    {
        // Loop through foodPreferences and find nearest food
        foreach (string food in foodPreferences)
        {
            

            // Create a list of all food objects
            GameObject[] foodObjects = GameObject.FindGameObjectsWithTag(food);

            // If not empty
            if (foodObjects.Length > 0)
            {
                // Pick a random food object
                int foodObjectIndex = Random.Range(0, foodObjects.Length);

                // Get the food object
                GameObject foodObject = foodObjects[foodObjectIndex];

                return foodObject;
            }

            return null;



        }

        return null;

    }

    // Shuffle the list
    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;

        }
    }
}
