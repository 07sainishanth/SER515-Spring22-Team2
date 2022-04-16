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
    public GameObject oneText;
    public GameObject twoText;
    public GameObject threeText;

    Rigidbody roverRigidbody;
    bool destroy;
    int frameCounter;

    // Start is called before the first frame update
    void Start()
    {
        roverRigidbody = rover.GetComponent<Rigidbody>();
        destroy = false;
        frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!destroy)
        {
            cameraRig.transform.position = rover.transform.position;

            if (Input.GetKeyDown(KeyCode.F) && EnvironmentSettings.robot == EnvironmentSettings.Robot.P_DESTROYER) // Switch cameras by pressing the 'F' Key
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

                if (Input.GetKeyDown(KeyCode.Space)) // Thrust upwards
                {
                    roverRigidbody.AddForce(cameraRig.transform.up * 12000.0f, ForceMode.Impulse);
                }

                if (Input.GetKeyDown(KeyCode.X)) // Detonate pyramid destroyer :D
                {
                    Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
                    roverRigidbody.velocity = zero;
                    roverRigidbody.angularVelocity = zero;
                    destroy = true;
                    threeText.SetActive(true);
                    roverCamera.SetActive(false);
                    mainCamera.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.Q)) // Stop moving
                {
                    Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
                    roverRigidbody.velocity = zero;
                    roverRigidbody.angularVelocity = zero;
                }
            }
        }
        else // Pyramid destroyer weapon engaged
        {
            frameCounter++;
            if (frameCounter == 20)
            {
                threeText.SetActive(false);
                twoText.SetActive(true);
            }
            else if (frameCounter == 40)
            {
                twoText.SetActive(false);
                oneText.SetActive(true);
            }
            else if (frameCounter == 60)
            {
                oneText.SetActive(false);
                roverRigidbody.mass = 1562500.0f;
                rover.transform.localScale *= 25.0f;
                Destroy(rover, 0.075f);
                destroy = true;
            }
        }
    }
}
