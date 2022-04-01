using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] GameObject FirstPersonCam;
    [SerializeField] GameObject ThirdPersonCam;
    int camMode;
    // Start is called before the first frame update
    void Start()
    {
        if(FirstPersonCam==null)
        {
            FirstPersonCam = GameObject.Find("firstPerson");
        }
        if(ThirdPersonCam==null)
        {
            print("Main camera not found");
            ThirdPersonCam = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Camera"))
        {
            if(camMode == 1)
                camMode = 0;
            else
            {
                camMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);

        if(camMode == 0)
        {
            ThirdPersonCam.SetActive(true);
            FirstPersonCam.SetActive(false);
        }
        else if (camMode == 1)
        {
            ThirdPersonCam.SetActive(false);
            FirstPersonCam.SetActive(true);
        }
    }
}
