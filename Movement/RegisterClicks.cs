using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterClicks : MonoBehaviour
{
    /* When the user clicks on the object, store the coordinates of where the user clicked on the object.*/

    // The mouse position
    public Vector3 clickedPosition;

    // When the user clicks on the object, the mouse position is stored in the mousePosition variable.
    void OnMouseDown()
    {
        // objectToMove every object with tag "Animal"
        GameObject[] objectsToMove = GameObject.FindGameObjectsWithTag("Animal");

        // Using rays TODO: wtf is this?
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        // Store the mouse position
        clickedPosition = hit.point;

        // Call the function in the Movement script and pass the gameObject
        // If the object is not null, then it will move
        if (objectsToMove != null)
        {
            foreach (GameObject objectToMove in objectsToMove)
            {

                // Set the target position to the mouse position
                objectToMove.GetComponent<Move>().targetPosition = clickedPosition;
                
                // Call the function in the Movement script and pass the gameObject
                objectToMove.GetComponent<Move>().isMoving = true;
            }

        }
    }
    
        
}
