using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWater : MonoBehaviour
{   

    // Function that finds nearest water
    public GameObject FindNearestWater(float range, Vector3 position)
    {

        // Create a list of all water objects
        GameObject[] waterObjects = GameObject.FindGameObjectsWithTag("Water");

        // Pick a random water object
        int waterObjectIndex = Random.Range(0, waterObjects.Length);

        // Get the water object
        GameObject waterObject = waterObjects[waterObjectIndex];

        return waterObject;
    }
}
