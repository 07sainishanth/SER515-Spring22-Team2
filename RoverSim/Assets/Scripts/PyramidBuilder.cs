using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is responsible for building a pyramid structure from cube-shaped blocks.
 * 
 * Author: David Bieganski
 */
public class PyramidBuilder : MonoBehaviour
{
    // North defined as positive Z direction
    // East defined as positive X direction
    // South defined as negative Z direction
    // West defined as negative X direction

    public static GameObject block;
    public static int levels;
    public static float xPos;
    public static float yPos;
    public static float zPos;

    // This method is used to build a pyramid out of blocks.
    public static void buildPyramid()
    {
        Quaternion rot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        Vector3 pos;
        
        // Build each level of the pyramid except for top level
        for (int i = 1; i <= levels - 1; i++)
        {
            float x = xPos - 0.5f * (levels - i);
            float y = yPos + 0.5f + i - 1;
            float z = zPos + 0.5f * (levels - i);

            // Set blocks on the north side
            while (x <= xPos + 0.5f * (levels - i))
            {
                pos = new Vector3(x, y, z);
                Instantiate(block, pos, rot).SetActive(true);
                x += 1;
            }
            x -= 1;
            z -= 1;

            // Set blocks on the east side
            while (z >= zPos - 0.5f * (levels - i))
            {
                pos = new Vector3(x, y, z);
                Instantiate(block, pos, rot).SetActive(true);
                z -= 1; 
            }
            z += 1;
            x -= 1;

            // set blocks on the south side
            while (x >= xPos - 0.5f * (levels - i))
            {
                pos = new Vector3(x, y, z);
                Instantiate(block, pos, rot).SetActive(true);
                x -= 1;

            }
            x += 1;
            z += 1;

            // Set blocks on the west side
            while (z <= zPos + 0.5f * (levels - i) - 1)
            {
                pos = new Vector3(x, y, z);
                Instantiate(block, pos, rot).SetActive(true);
                z += 1;
            }
        }

        // Set the top block
        pos = new Vector3(xPos, yPos + 0.5f + levels - 1, zPos);
        Instantiate(block, pos, rot).SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}