using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontFall : MonoBehaviour
{
    /* This ensures that the object rotation is always standing up */

    // Current rotation
    public Quaternion currentRotation;

    // Set Rotation
    public Vector3 hardRotation;

    // Rotation threshold
    public float rotationThreshold = 50;

    // Update is called once per frame
    void Update()
    {
        // Update the current rotation
        currentRotation = transform.rotation;

        transform.rotation = new Quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        
    }
}

