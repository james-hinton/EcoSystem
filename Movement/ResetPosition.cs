using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If V is pressed, reset the position of the object
        if (Input.GetKeyDown(KeyCode.V))
        {
            transform.position = new Vector3(0, 10, 20);
        }
        
    }
}
