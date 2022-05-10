using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    // Is Moving
    public bool isMoving = true;

    // Bobble Intensity
    public float bobbleIntensity = 2f;

    // Current Location
    private Vector3 currentLocation;

    // Target Location
    public Vector3 targetLocation;

    // Start is called before the first frame update
    void Start()
    {
        // Set Current Location
        currentLocation = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Bobble up and down with a sine wave on current position
        if (isMoving)
        {
            // Using current location, bobble up and down
            transform.position = new Vector3(currentLocation.x, (Mathf.Sin(Time.time * bobbleIntensity) * 0.2f) + currentLocation.y, currentLocation.z);

        }
        
    }
}
