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

    // Added hunger per tick
    public float hungerPerTick;

    // Added thirst per tick
    public float thirstPerTick;

    // Array of food preferences
    public string[] foodPreferences;

    // Range
    public float range;

    // Life span in seconds
    public float lifeSpan;

    // Reproduction rate
    public float reproductionDelay; 

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
        hunger += hungerPerTick;

        // Increase thirst by 0.1
        thirst += thirstPerTick;
    }

    // Update is called once per frame
    void Update()
    {

        // Life span
        lifeSpan += 1;

        // Lifespan check, 10,000 * reproductionDelay
        if (lifeSpan % (10_000 * reproductionDelay)  == 0) {
            // Create new Animal Game Object
            SpawnAnimal spawnAnimal = new SpawnAnimal();

            // Pass prefab in
            spawnAnimal.prefab = gameObject;

            // Spawn the animal
            spawnAnimal.Spawn();

        }
        
        Move move = GetComponent<Move>();
        // Only call if isMoving is false
        if (move) {

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

    public static Vector3 RandomPointInBounds(Bounds bounds) {
    return new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        Random.Range(bounds.min.z, bounds.max.z)
    );
}

    public void MoveWater( Move move) {
        // Create Find Water object
        FindWater findWater = new FindWater();

        // Find water
        GameObject waterObject = findWater.FindNearestWater(range, transform.position);

        // Move towards water
        if (waterObject != null)
        {
            // Pick a position anywhere in the water object
            Vector3 waterLocation = RandomPointInBounds(waterObject.GetComponent<Collider>().bounds);

            // Set target position to water location
            move.targetPosition = waterLocation;

            // Set isMoving to true
            move.isMoving = true;

            // Stop update
            return;
        }
    }

    // If it collides with tag "Food"
    private void OnTriggerEnter(Collider other)
    {
        // Check all child object of other
        foreach (Transform child in other.transform)
        {
            // Tag
            string tag = child.tag;

            foreach (string food in foodPreferences)
            {

                // If the tag is in the array
                if (tag == food)
                {
                    
                    // Get the object we have collided with
                    GameObject collidedObject = other.gameObject;

                    // Destroy the collided object
                    // Check if original object is hungry
                    if (hunger > 0.25f) {
                        Destroy(collidedObject);
                        hunger -= 0.2f;
                    }

                    // Increase the size of the thing
                    // transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

                    // Unless hunger is less than 0
                    if (hunger < 0)
                    {
                        // Set hunger to 0
                        hunger = 0;
                    }

                    // Stop moving
                    Move move = GetComponent<Move>();
                    if (move) {
                        move.isMoving = false;
                    }
                }
            }

        }
        // Loop through foodPreferences and see if the tag is in the array

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

    // On trigger stay
    private void OnTriggerStay(Collider other)
    {
        // If the tag is "Water"
        if (other.tag == "Water")
        {
            // Thirst is always 0
            thirst = 0;
        }
    }

    // Function that returns given stat
    public float GetStat(string stat) {
        if (stat == "hunger") {
            return hunger;
        } else if (stat == "thirst") {
            return thirst;
        }
        return 0;
    }

}
