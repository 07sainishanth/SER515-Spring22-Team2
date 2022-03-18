using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class handles the mouse input for controlling the camera in the navigation scene.
 * 
 * Author: David Bieganski
 */
public class CameraController : MonoBehaviour
{
    // Left button: 0
    // Right button: 1
    // Middle button: 2

    float rotateSpeed = 5.0f;
    float scrollSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        // Rotate camera while right button is pressed
        if (Input.GetMouseButton(1))
        {
            float yRotation = rotateSpeed * Input.GetAxis("Mouse X");
            float xRotation = rotateSpeed * -Input.GetAxis("Mouse Y");
            transform.Rotate(xRotation, 0.0f, 0.0f); // Space.Self
            transform.Rotate(0f, yRotation, 0.0f, Space.World);
        }

        // Move camera along Z-axis using the scroll wheel
        float yDelta = Input.mouseScrollDelta.y;
        transform.Translate(0.0f, 0.0f, scrollSpeed * yDelta, Space.Self);
    }
}
