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
    public const float BASE_VALUE = 4.0f;
    
    public static float scaleX = BASE_VALUE;
    public static float scaleZ = BASE_VALUE;

    // This method is used for setting the scale based on the value of the slider.
    public static void setScale(float v)
    {
        scaleX = BASE_VALUE + v * Random.Range(1, 4);
        Debug.Log("X-scale: " + scaleX);
        scaleZ = BASE_VALUE + v * Random.Range(1, 4);
        Debug.Log("Z-scale: " + scaleZ);
    }
}
