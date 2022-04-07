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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
