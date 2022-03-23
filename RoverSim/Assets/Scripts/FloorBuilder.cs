using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class handles setting the scale of the floor, sand, and perimeter walls and 
 * positioning of perimeter walls in navigation scene.
 * 
 * Author: David Bieganski
 */
public class FloorBuilder : MonoBehaviour
{
    public GameObject floor;
    public GameObject sand;
    public GameObject northWall;
    public GameObject eastWall;
    public GameObject southWall;
    public GameObject westWall;

    Vector3 floorScale;
    Vector3 sandScale;
    Vector3 north_southWallScale;
    Vector3 east_westWallScale;

    Vector3 northWallPos;
    Vector3 eastWallPos;
    Vector3 southWallPos;
    Vector3 westWallPos;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        floorScale = new Vector3(EnvironmentSettings.scaleX + 0.4f, 1.0f, EnvironmentSettings.scaleZ + 0.4f);
        sandScale = new Vector3(EnvironmentSettings.scaleX, 1.0f, EnvironmentSettings.scaleZ);
        floor.transform.localScale = floorScale;
        sand.transform.localScale = sandScale;
        */
        int xTiles = (int) System.Math.Round(EnvironmentSettings.scaleX / floor.transform.localScale.x);
        int zTiles = (int) System.Math.Round(EnvironmentSettings.scaleZ / floor.transform.localScale.z);
        Quaternion rot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        Vector3 quarterScale = new Vector3(0.2f, 1.0f, 0.2f);

        float xStart = -4 * 0.5f * xTiles - 2;
        float zStart = 4 * 0.5f * zTiles + 2;
        
        for (int z = zTiles; z > 0; z--)
        {
            for (int x = 1; x <= xTiles; x++)
            {
                float xPos = xStart + x * 4;
                float zPos = zStart - z * 4;
                Vector3 pos = new Vector3(xPos, 0.0f, zPos);
                Instantiate(floor, pos, rot).SetActive(true);
                Instantiate(sand, pos, rot).SetActive(true);
            }
        }

        // Place floor tiles underneath north perimeter wall
        xStart = -2 * xTiles - 3;
        zStart = 2 * zTiles + 1;
        for (int x = 2; x < 2 * xTiles + 2; x++) 
        {
            float xPos = xStart + x * 2;
            float zPos = zStart;
            Vector3 pos = new Vector3(xPos, 0.0f, zPos);
            GameObject quarterFloor = Instantiate(floor, pos, rot);
            quarterFloor.transform.localScale = quarterScale;
            quarterFloor.SetActive(true);
        }

        // Place floor tiles underneath east perimeter wall
        xStart = 2 * xTiles + 1;
        for (int z = 0; z < 2 * zTiles + 2; z++)
        {
            float xPos = xStart;
            float zPos = zStart - z * 2;
            Vector3 pos = new Vector3(xPos, 0.0f, zPos);
            GameObject quarterFloor = Instantiate(floor, pos, rot);
            quarterFloor.transform.localScale = quarterScale;
            quarterFloor.SetActive(true);
        }

        // Place floor tiles underneath south perimeter wall
        xStart = 2 * xTiles + 3;
        zStart = -2 * zTiles - 1;
        for (int x = 2; x < 2 * xTiles + 2; x++)
        {
            float xPos = xStart - x * 2;
            float zPos = zStart;
            Vector3 pos = new Vector3(xPos, 0.0f, zPos);
            GameObject quarterFloor = Instantiate(floor, pos, rot);
            quarterFloor.transform.localScale = quarterScale;
            quarterFloor.SetActive(true);
        }

        // Place floor tiles underneath west perimeter wall
        xStart = -2 * xTiles - 1;
        zStart = -2 * zTiles;
        for (int z = 0; z < 2 * zTiles + 2; z++)
        {
            float xPos = xStart;
            float zPos = zStart + z * 2 - 1;
            Vector3 pos = new Vector3(xPos, 0.0f, zPos);
            GameObject quarterFloor = Instantiate(floor, pos, rot);
            quarterFloor.transform.localScale = quarterScale;
            quarterFloor.SetActive(true);
        }


        north_southWallScale = new Vector3(10 * EnvironmentSettings.scaleX, 8.0f, 2.0f);
        northWall.transform.localScale = north_southWallScale;
        southWall.transform.localScale = north_southWallScale;

        east_westWallScale = new Vector3(2.0f, 8.0f, 10 * EnvironmentSettings.scaleZ + 4.0f);
        eastWall.transform.localScale = east_westWallScale;
        westWall.transform.localScale = east_westWallScale;

        northWallPos = new Vector3(0.0f, 4.0f, 5 * EnvironmentSettings.scaleZ + 1.0f);
        northWall.transform.position = northWallPos;
        northWall.GetComponent<Rigidbody>().mass = 10 * EnvironmentSettings.scaleX * 8.0f * 2.0f;


        eastWallPos = new Vector3(5 * EnvironmentSettings.scaleX + 1.0f, 4.0f, 0.0f);
        eastWall.transform.position = eastWallPos;
        eastWall.GetComponent<Rigidbody>().mass = 2.0f * 8.0f * 10 * EnvironmentSettings.scaleZ + 64.0f;

        southWallPos = new Vector3(0.0f, 4.0f, -5 * EnvironmentSettings.scaleZ - 1.0f);
        southWall.transform.position = southWallPos;
        southWall.GetComponent<Rigidbody>().mass = 10 * EnvironmentSettings.scaleX * 8.0f * 2.0f;

        westWallPos = new Vector3(-5 * EnvironmentSettings.scaleX - 1.0f, 4.0f, 0.0f);
        westWall.transform.position = westWallPos;
        westWall.GetComponent<Rigidbody>().mass = 2.0f * 8.0f * EnvironmentSettings.scaleZ + 64.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
