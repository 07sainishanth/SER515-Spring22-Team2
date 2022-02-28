using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/**
 * This class maintains the settings used for generating the simulation environment.
 * 
 * Author: David Bieganski
 */
public class EnvironmentSettings : MonoBehaviour
{
    const float BASE_VALUE = 4.0f;
    
    float scaleX = BASE_VALUE;
    float scaleZ = BASE_VALUE;

    // Start
    void Start()
    {

    }

    // This method is used for setting the scale based on the value of the slider.
    public void setScale(float v)
    {
        scaleX = BASE_VALUE + v * Random.Range(1, 3);
        scaleZ = BASE_VALUE + v * Random.Range(1, 3);
    }
}
