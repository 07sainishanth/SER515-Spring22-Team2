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
        int centerBlock = levels / 2;
        Vector3 halfScaleX = new Vector3(0.5f, 1.0f, 1.0f);
        Vector3 halfScaleZ = new Vector3(1.0f, 1.0f, 0.5f);
        int r = (int) Random.Range(1, 5);
        
        // Build each level of the pyramid except for top level
        for (int i = 1; i <= levels - 1; i++)
        {
            float x = xPos - 0.5f * (levels - i);
            float y = yPos + 0.5f + i - 1;
            float z = zPos + 0.5f * (levels - i);
            int b = 0; // Current block being added to the row (used for creating the entrance)

            // Set blocks on the north side
            while (x <= xPos + 0.5f * (levels - i))
            {
                if (r == 1 && (i == 1 || i == 2 || i == 3)) // Consider first three levels for pyramid entrance
                {
                    if (levels % 2 == 1) // Pyramid has odd number of levels
                    {
                        // Do not add block where opening is
                        if (i == 1 && (b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1)) x += 1;
                        else if (i == 2 & (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 2)
                            {
                                pos = new Vector3(x - 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock + 1)
                            {
                                pos = new Vector3(x + 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            x += 1;
                        }
                        else if (i == 3 && (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock)) x += 1;
                        else // Add the block
                        {
                            pos = new Vector3(x, y, z);
                            Instantiate(block, pos, rot).SetActive(true);
                            x += 1;
                        }
                        b++;
                    }
                    else // Pyramid has even number of levels
                    {
                        // Do not add block where opening is
                        if (i == 1 && (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 2)
                            {
                                pos = new Vector3(x - 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock + 1)
                            {
                                pos = new Vector3(x + 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            x += 1;
                        }
                        else if (i == 2 & (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock)) x += 1;
                        else if (i == 3 && (b == centerBlock - 3 || b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 3)
                            {
                                pos = new Vector3(x - 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock)
                            {
                                pos = new Vector3(x + 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            x += 1;
                        }
                        else // Add the block
                        {
                            pos = new Vector3(x, y, z);
                            Instantiate(block, pos, rot).SetActive(true);
                            x += 1;
                        }
                        b++;
                    }

                }
                else
                {
                    pos = new Vector3(x, y, z);
                    Instantiate(block, pos, rot).SetActive(true);
                    x += 1;
                }
            }
            x -= 1;
            z -= 1;
            b = 1;

            // Set blocks on the east side
            while (z >= zPos - 0.5f * (levels - i))
            {
                if (r == 2 && (i == 1 || i == 2 || i == 3)) // Consider first three levels for pyramid entrance
                {
                    if (levels % 2 == 1) // Pyramid has odd number of levels
                    {
                        // Do not add block where opening is
                        if (i == 1 && (b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1)) z -= 1;
                        else if (i == 2 & (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 2)
                            {
                                pos = new Vector3(x, y, z + 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock + 1)
                            {
                                pos = new Vector3(x, y, z - 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            z -= 1;
                        }
                        else if (i == 3 && (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock)) z -= 1;
                        else // Add the block
                        {
                            pos = new Vector3(x, y, z);
                            Instantiate(block, pos, rot).SetActive(true);
                            z -= 1;
                        }
                        b++;
                    }
                    else // Pyramid has even number of levels
                    {
                        // Do not add block where opening is
                        if (i == 1 && (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 2)
                            {
                                pos = new Vector3(x, y, z + 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock + 1)
                            {
                                pos = new Vector3(x, y, z - 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            z -= 1;
                        }
                        else if (i == 2 & (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock)) z -= 1;
                        else if (i == 3 && (b == centerBlock - 3 || b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 3)
                            {
                                pos = new Vector3(x, y, z + 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock)
                            {
                                pos = new Vector3(x, y, z - 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            z -= 1;
                        }
                        else // Add the block
                        {
                            pos = new Vector3(x, y, z);
                            Instantiate(block, pos, rot).SetActive(true);
                            z -= 1;
                        }
                        b++;
                    }

                }
                else
                {
                    pos = new Vector3(x, y, z);
                    Instantiate(block, pos, rot).SetActive(true);
                    z -= 1;
                }
            }
            z += 1;
            x -= 1;
            b = 1;

            // set blocks on the south side
            while (x >= xPos - 0.5f * (levels - i))
            {
                if (r == 3 && (i == 1 || i == 2 || i == 3)) // Consider first three levels for pyramid entrance
                {
                    if (levels % 2 == 1) // Pyramid has odd number of levels
                    {
                        // Do not add block where opening is
                        if (i == 1 && (b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1)) x -= 1;
                        else if (i == 2 & (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 2)
                            {
                                pos = new Vector3(x + 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock + 1)
                            {
                                pos = new Vector3(x - 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            x -= 1;
                        }
                        else if (i == 3 && (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock)) x -= 1;
                        else // Add the block
                        {
                            pos = new Vector3(x, y, z);
                            Instantiate(block, pos, rot).SetActive(true);
                            x -= 1;
                        }
                        b++;
                    }
                    else // Pyramid has even number of levels
                    {
                        // Do not add block where opening is
                        if (i == 1 && (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock|| b == centerBlock + 1))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 2)
                            {
                                pos = new Vector3(x + 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock + 1)
                            {
                                pos = new Vector3(x - 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            x -= 1;
                        }
                        else if (i == 2 & (b == centerBlock - 2 || b == centerBlock -1 || b == centerBlock)) x -= 1;
                        else if (i == 3 && (b == centerBlock - 3 || b == centerBlock - 2 || b == centerBlock - 1|| b == centerBlock))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 3)
                            {
                                pos = new Vector3(x + 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock)
                            {
                                pos = new Vector3(x - 0.25f, y, z);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleX;
                                halfblock.SetActive(true);
                            }
                            x -= 1;
                        }
                        else // Add the block
                        {
                            pos = new Vector3(x, y, z);
                            Instantiate(block, pos, rot).SetActive(true);
                            x -= 1;
                        }
                        b++;
                    }
                    
                }
                else
                {
                    pos = new Vector3(x, y, z);
                    Instantiate(block, pos, rot).SetActive(true);
                    x -= 1;
                }
            }
            x += 1;
            z += 1;
            b = 1;

            // Set blocks on the west side
            while (z <= zPos + 0.5f * (levels - i) - 1)
            {
                if (r == 4 && (i == 1 || i == 2 || i == 3)) // Consider first three levels for pyramid entrance
                {
                    if (levels % 2 == 1) // Pyramid has odd number of levels
                    {
                        // Do not add block where opening is
                        if (i == 1 && (b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1)) z += 1;
                        else if (i == 2 & (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 2)
                            {
                                pos = new Vector3(x, y, z - 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock + 1)
                            {
                                pos = new Vector3(x, y, z + 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            z += 1;
                        }
                        else if (i == 3 && (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock)) z += 1;
                        else // Add the block
                        {
                            pos = new Vector3(x, y, z);
                            Instantiate(block, pos, rot).SetActive(true);
                            z += 1;
                        }
                        b++;
                    }
                    else // Pyramid has even number of levels
                    {
                        // Do not add block where opening is
                        if (i == 1 && (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock || b == centerBlock + 1))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 2)
                            {
                                pos = new Vector3(x, y, z - 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock + 1)
                            {
                                pos = new Vector3(x, y, z + 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            z += 1;
                        }
                        else if (i == 2 & (b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock)) z += 1;
                        else if (i == 3 && (b == centerBlock - 3 || b == centerBlock - 2 || b == centerBlock - 1 || b == centerBlock))
                        {
                            // Install half blocks at the edge of opening
                            if (b == centerBlock - 3)
                            {
                                pos = new Vector3(x, y, z - 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            else if (b == centerBlock)
                            {
                                pos = new Vector3(x, y, z + 0.25f);
                                GameObject halfblock = Instantiate(block, pos, rot);
                                halfblock.transform.localScale = halfScaleZ;
                                halfblock.SetActive(true);
                            }
                            z += 1;
                        }
                        else // Add the block
                        {
                            pos = new Vector3(x, y, z);
                            Instantiate(block, pos, rot).SetActive(true);
                            z += 1;
                        }
                        b++;
                    }

                }
                else
                {
                    pos = new Vector3(x, y, z);
                    Instantiate(block, pos, rot).SetActive(true);
                    z += 1;
                }
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
