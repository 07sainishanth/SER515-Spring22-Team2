using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject mainCam;
   public GameObject chassisCam;
void Start()
    {
        mainCam.SetActive(true);
        chassisCam.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("SKey"))
        {
            mainCam.SetActive(false);
            chassisCam.SetActive(true);
        }
        
    }
}
