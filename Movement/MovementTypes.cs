using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create a Movement Types Namespace
namespace MovementTypes
{
    // Create a Bounce Class
    public class Bounce
    {
        // Move
        public void Move(GameObject gameObject)
        {
            // Get speed
            float speed = gameObject.GetComponent<Move>().speed;

            // Get transform
            Transform transform = gameObject.transform;

            // Get the current position of the thing
            Vector3 currentPosition = transform.position;

            // Get target position
            Vector3 targetPosition = gameObject.GetComponent<Move>().targetPosition;

            // Move towards the target position
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

            // Rotate the Y axis to point towards the target position
            // Randomly change the Y axis rotation
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // If we've arrived close enough to the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.4f)
            {
                // Set isMoving to false
                gameObject.GetComponent<Move>().isMoving = false;
            }
            
        }

    }

        // Create a Slide Class
    public class Slide
    {
        // Move
        public void Move(GameObject gameObject)
        {
            // Get speed
            float speed = gameObject.GetComponent<Move>().speed;

            // Get transform
            Transform transform = gameObject.transform;

            // Get the current position of the thing
            Vector3 currentPosition = transform.position;

            // Get target position
            Vector3 targetPosition = gameObject.GetComponent<Move>().targetPosition;

            // Dont let targetPosition be greater than the objects Y height
            if (targetPosition.y > transform.position.y)
            {
                targetPosition.y = transform.position.y;
            }
            // Move towards the target position
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

            // Point the Y axis towards the target position
            transform.LookAt(targetPosition);

            // If we've arrived close enough to the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.4f)
            {
                // Set isMoving to false
                gameObject.GetComponent<Move>().isMoving = false;
            }
            
        }

    }
}