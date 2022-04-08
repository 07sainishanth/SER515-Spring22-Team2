using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This controller class is used for switching the cameras and manually moving the rover.
 * 
 * Author: David Bieganski
 */
public class MovementController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject roverCamera;
    public GameObject cameraRig;
    public GameObject rover;

    Rigidbody roverRigidbody;
    bool destroy;

    // Start is called before the first frame update
    void Start()
    {
        roverRigidbody = rover.GetComponent<Rigidbody>();
        destroy = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!destroy)
        {
            cameraRig.transform.position = rover.transform.position;

            if (Input.GetKeyDown(KeyCode.F)) // Switch cameras by pressing the 'F' Key
            {
                if (mainCamera.activeInHierarchy)
                {
                    roverCamera.SetActive(true);
                    mainCamera.SetActive(false);
                }
                else
                {
                    roverCamera.SetActive(false);
                    mainCamera.SetActive(true);
                }
            }

            if (roverCamera.activeInHierarchy) // Only move rover when rover Camera is active
            {
                if (Input.GetKey(KeyCode.A)) // Rotate the camera counterclockwise
                {
                    cameraRig.transform.RotateAround(cameraRig.transform.position, Vector3.up, -45 * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.D)) // Rotate camera clockwise
                {
                    cameraRig.transform.RotateAround(cameraRig.transform.position, Vector3.up, 45 * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.W)) // Move forward
                {
                    rover.transform.Translate(10 * cameraRig.transform.forward * Time.deltaTime, Space.World);
                }

                if (Input.GetKey(KeyCode.S)) // Move backward
                {
                    rover.transform.Translate(-10 * cameraRig.transform.forward * Time.deltaTime, Space.World);
                }

                if (Input.GetKeyDown(KeyCode.Space) && rover.transform.localPosition.y <= 1.5) // Thrust upwards from ground
                {
                    roverRigidbody.AddForce(cameraRig.transform.up * 16000.0f, ForceMode.Impulse);
                }

                if (Input.GetKeyDown(KeyCode.X)) // Detonate pyramid destroyer :D
                {
                    rover.transform.localScale *= 25.0f;
                    Destroy(rover, 0.05f);
                    destroy = true;
                    roverCamera.SetActive(false);
                    mainCamera.SetActive(true);
                }
            }
        }
    }
}
