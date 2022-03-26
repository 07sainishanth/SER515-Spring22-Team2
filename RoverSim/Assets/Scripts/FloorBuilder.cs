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
    public GameObject water;
    public GameObject subfloor;
    public GameObject northSubWall;
    public GameObject eastSubWall;
    public GameObject southSubWall;
    public GameObject westSubWall;

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

        float xStart = -xTiles + 1;
        float zStart = zTiles - 1;
        
        for (int z = 0; z < zTiles; z++)
        {
            for (int x = 0; x < xTiles; x++)
            {
                // Don't place floor or sand tiles in north-western region of map
                if (!(z == 4 || z == 5 || z == 6 || z == 7) || !(x == 4 || x == 5 || x == 6 || x ==7))
                {
                    float xPos = xStart + x * 2;
                    float zPos = zStart - z * 2;
                    Vector3 pos = new Vector3(xPos, 0.0f, zPos);
                    Instantiate(floor, pos, rot).SetActive(true);
                    pos = new Vector3(xPos, 0.1f, zPos);
                    Instantiate(sand, pos, rot).SetActive(true);
                }
            }
        }

        // Place floor tiles underneath north perimeter wall
        xStart = -xTiles - 1;
        zStart = zTiles + 1;
        for (int x = 0; x < xTiles + 2; x++) 
        {
            float xPos = xStart + x * 2;
            float zPos = zStart;
            Vector3 pos = new Vector3(xPos, 0.0f, zPos);
            Instantiate(floor, pos, rot).SetActive(true);
        }

        // Place floor tiles underneath east perimeter wall
        xStart = xTiles + 1;
        for (int z = 0; z < zTiles + 2; z++)
        {
            float xPos = xStart;
            float zPos = zStart - z * 2;
            Vector3 pos = new Vector3(xPos, 0.0f, zPos);
            Instantiate(floor, pos, rot).SetActive(true);
        }

        // Place floor tiles underneath south perimeter wall
        xStart = xTiles - 1;
        zStart = -zTiles - 1;
        for (int x = 0; x < xTiles + 1; x++)
        {
            float xPos = xStart - x * 2;
            float zPos = zStart;
            Vector3 pos = new Vector3(xPos, 0.0f, zPos);
            Instantiate(floor, pos, rot).SetActive(true);
        }

        // Place floor tiles underneath west perimeter wall
        xStart = -xTiles - 1;
        zStart = -zTiles + 1;
        for (int z = 0; z < zTiles; z++)
        {
            float xPos = xStart;
            float zPos = zStart + z * 2;
            Vector3 pos = new Vector3(xPos, 0.0f, zPos);
            Instantiate(floor, pos, rot).SetActive(true);
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

        // Build the water feature
        Instantiate(water, new Vector3(-xTiles + 12.0f, 0.1f, zTiles - 12.0f), rot).SetActive(true);
        Instantiate(subfloor, new Vector3(-xTiles + 12.0f, -8.0f, zTiles - 12.0f), rot).SetActive(true);
        Instantiate(northSubWall, new Vector3(-xTiles + 12.0f, -4.0f, zTiles - 8.0f), new Quaternion(-1.0f, 0.0f, 0.0f, 1.0f)).SetActive(true);
        Instantiate(eastSubWall, new Vector3(-xTiles + 16.0f, -4.0f, zTiles - 12.0f), new Quaternion(0.0f, 0.0f, 1.0f, 1.0f)).SetActive(true);
        Instantiate(southSubWall, new Vector3(-xTiles + 12.0f, -4.0f, zTiles - 16.0f), new Quaternion(1.0f, 0.0f, 0.0f, 1.0f)).SetActive(true);
        Instantiate(westSubWall, new Vector3(-xTiles + 8.0f, -4.0f, zTiles - 12.0f), new Quaternion(0.0f, 0.0f, -1.0f, 1.0f)).SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
