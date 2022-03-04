using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverController : MonoBehaviour
{
    // Controls
    // F-Key: Switch Camera

    public GameObject skyCamera;
    public GameObject roverCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (skyCamera.activeSelf)
            {
                skyCamera.SetActive(false);
                roverCamera.SetActive(true);
            }
            else
            {
                skyCamera.SetActive(true);
                roverCamera.SetActive(false);
            }
        }
    }

    public void switchCamera()
    {
        
        Debug.Log("");
    }
}
