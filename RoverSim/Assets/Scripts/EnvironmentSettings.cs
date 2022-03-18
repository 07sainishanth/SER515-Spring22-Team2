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
    public static float spaceObjectCount = 4;
    public static int pyramidCount = 1;
    public static int largeBoulderCount = 2;
    public static int colossalBoulderCount = 1;
    public static int spaceMonolithCount = 1;
    public static int meteorCount = 1;

    // This method is used for setting the scale based on the value of the slider.
    public static void setScale(float v)
    {
        scaleX = BASE_VALUE + (float) System.Math.Round(v) * Random.Range(1, 5);
        Debug.Log("X-scale: " + scaleX);
        scaleZ = BASE_VALUE + (float) System.Math.Round(v) * Random.Range(1, 5);
        Debug.Log("Z-scale: " + scaleZ);
    }

    /*
     * This method is used for setting the number of physical objects that will appear
     * in the navigation scene.
     */
    public static void setObjectCounts(float v)
    {
        spaceObjectCount = (int) (v * Random.Range(1, 4) * scaleX * scaleZ / 32);
        pyramidCount = (int) (v * Random.Range(1, 2) * scaleX * scaleZ / 240);
        largeBoulderCount = (int) (v * Random.Range(1, 3) * scaleX * scaleZ / 240);
        colossalBoulderCount = (int) (v * Random.Range(1, 2) * scaleX * scaleZ / 480);
        spaceMonolithCount = (int) (v * Random.Range(1, 2) * scaleX * scaleZ / 320);
        meteorCount = 0; // Implement later
    }
}
