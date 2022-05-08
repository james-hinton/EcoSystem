using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MovementTypes;
public class Move : MonoBehaviour
{   
    /*
        This class controls the movement of the thing.
        It takes in the position of where it must be and controls how it moves there.
    */

    // Set isMoving to false
    public bool isMoving = false;
    
    // Read the Vector3 from the RegisterClicks script
    public Vector3 targetPosition;

    // Current position of the thing
    public Vector3 currentPosition;

    // Movement Type dropdown either Bounce or Slide
    public string movementType;
    
    // Speed of movement
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        
        
        // If isMoving is true
        if (isMoving)
        {
            // Get the X distance between the current position and the target position
            float xDistance = targetPosition.x - currentPosition.x;

            // Get the Z distance between the current position and the target position
            float zDistance = targetPosition.z - currentPosition.z;

            // If the x and z distance is close enough, stop moving
            if (Mathf.Abs(xDistance) < 0.2f && Mathf.Abs(zDistance) < 0.2f)
            {
                isMoving = false;
            }

            // If movementType is "slide"
            if (movementType == "slide")
            {
                MovementTypes.Slide slide = new MovementTypes.Slide();
                slide.Move(gameObject);
            }
        }

        // Update the current position
        currentPosition = transform.position;
    }


}
