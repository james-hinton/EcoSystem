using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FoodObject;

public class SpawnAnimal : MonoBehaviour
{
    public GameObject prefab;

    // Function to spawn the Animal
    public void Spawn()
    {       
        // Create new Animal object
        AnimalObject animalObject = new AnimalObject();

        // Get position at 0,2,0
        Vector3 position = new Vector3(0, 2, 0);

        // Spawn the Animal
        animalObject.Spawn(prefab, position);
    }

}
