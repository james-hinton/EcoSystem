using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FindFood;

public class AnimalObject : MonoBehaviour
{
    // Hunger between 0 and 1
    public float hunger;

    // Thirst between 0 and 1
    public float thirst;

    // Array of food preferences
    public string[] foodPreferences;

    // Range
    public float range;

    // Life span in seconds
    public float lifeSpan;

    


    

    // Create Animal Game Object with the prefab and collider
    public void Spawn(GameObject prefab, Vector3 position)
    {
        // Create new Animal Game Object
        GameObject animal = Instantiate(prefab, position, Quaternion.identity) as GameObject;
        
    }

    // Start
    void Start()
    {
        // Invoke Repeating every 5 seconds CostOfLiving
        InvokeRepeating("CostOfLiving", 0, 5);
    }

    void CostOfLiving() {
        // Increase hunger by 0.1
        hunger += 0.1f;

        // Increase thirst by 0.1
        thirst += 0.15f;
    }

    // Update is called once per frame
    void Update()
    {

        // Life span
        lifeSpan += 1;

        // If lifespan divisible by 100,000
        if (lifeSpan % 100_000 == 0) {
            // Create new Animal Game Object
            SpawnAnimal spawnAnimal = new SpawnAnimal();

            // Pass prefab in
            spawnAnimal.prefab = gameObject;

            // Spawn the animal
            spawnAnimal.Spawn();

        }
        
        Move move = GetComponent<Move>();
        // Only call if isMoving is false
        if (move.isMoving) {
            return;
        }

        // Which hunger or thirst is a higher value
        float highestValue = Mathf.Max(hunger, thirst);

        // If highestValue is greater than 1
        if (highestValue > 1) {
            // Destroy
            Destroy(gameObject);
        }

        // Checks whether the animal is more hungry or thirsty and whether theyre higher than 0.5f
        if (hunger > thirst) {
            // MoveFood
            if (hunger > 0.1f) {
                MoveFood(move);
            }
        } else {
            // MoveWater
            if (thirst > 0.25f) {
                MoveWater(move);
            }
        }

    }

    public void MoveFood( Move move) {
        // Create Find Food object
        FindFood findFood = new FindFood();

        // Find food
        GameObject food = findFood.FindNearestFood(foodPreferences, range, transform.position);
        // Move towards food
        if (food != null)
        {
            // Set target position to food location
            move.targetPosition = food.transform.position;

            // Set isMoving to true
            move.isMoving = true;

            // Stop update
            return;
        }
    }

    public void MoveWater( Move move) {
        // Create Find Water object
        FindWater findWater = new FindWater();

        // Find water
        GameObject water = findWater.FindNearestWater(range, transform.position);

        // Move towards water
        if (water != null)
        {
            // Set target position to water location
            move.targetPosition = water.transform.position;

            // Set isMoving to true
            move.isMoving = true;

            // Stop update
            return;
        }
    }

        // If it collides with tag "Food"
    private void OnTriggerEnter(Collider other)
    {
        // If the tag is "Food"
        if (other.tag == "Food" || other.tag == "Apple")
        {
            // Get the object we have collided with
            GameObject collidedObject = other.gameObject;

            // Destroy the collided object
            Destroy(collidedObject);

            // Increase the size of the thing
            // transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

            // Reduce the hunger
            hunger -= 0.2f;

            // Stop moving
            Move move = GetComponent<Move>();
            move.isMoving = false;

        }

        if (other.tag == "Water")
        {
            // Get the object we have collided with
            GameObject collidedObject = other.gameObject;

            // TODO: Reduce the width of the collided object
            // collidedObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

            // Reduce the thirst but not below 0
            thirst -= 0.2f;
            if (thirst < 0) {
                thirst = 0;
            }
        }
            
    }

}
