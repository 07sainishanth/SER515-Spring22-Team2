using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private GameObject FirstPersonCam;
    [SerializeField] private GameObject ThirdPersonCam;
    public enum cameraMode
    {
        Thirdperson = 0,
        FirstPerson = 1
    }

    int camMode;
    // Start is called before the first frame update
    void Start()
    {
        if(FirstPersonCam==null)
        {
            print("First person camera not found");
            FirstPersonCam = GameObject.Find("firstPerson");
        }
        if(ThirdPersonCam==null)
        {
            print("Third person camera not found");
            ThirdPersonCam = GameObject.Find("thirdPerson");
        }
        ThirdPersonCam.SetActive(false);
        FirstPersonCam.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(camMode == 1)
            {
                camMode = 0;
                ThirdPersonCam.SetActive(true);
                FirstPersonCam.SetActive(false);
            }
            else
            {
                camMode += 1;
                ThirdPersonCam.SetActive(false);
                FirstPersonCam.SetActive(true);
            }
            print(((cameraMode) camMode).ToString());
        }
    }
}
