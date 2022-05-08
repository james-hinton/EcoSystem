using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour
{
    // Create Food Game Object with the prefab and collider
    public void Spawn(GameObject prefab, Vector3 position)
    {
        // Create new Food Game Object
        GameObject food = Instantiate(prefab, position, Quaternion.identity) as GameObject;

        // Create new Cube Collider
        Collider foodCollider = food.AddComponent<BoxCollider>();

        // Set the food's collider to be a trigger
        foodCollider.isTrigger = true;
    }
}
