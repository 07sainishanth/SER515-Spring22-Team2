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
        floorScale = new Vector3(EnvironmentSettings.scaleX + 0.4f, 1.0f, EnvironmentSettings.scaleZ + 0.4f);
        sandScale = new Vector3(EnvironmentSettings.scaleX, 1.0f, EnvironmentSettings.scaleZ);
        floor.transform.localScale = floorScale;
        sand.transform.localScale = sandScale;

        north_southWallScale = new Vector3(10 * EnvironmentSettings.scaleX, 8.0f, 2.0f);
        northWall.transform.localScale = north_southWallScale;
        southWall.transform.localScale = north_southWallScale;

        east_westWallScale = new Vector3(2.0f, 8.0f, 10 * EnvironmentSettings.scaleZ + 4.0f);
        eastWall.transform.localScale = east_westWallScale;
        westWall.transform.localScale = east_westWallScale;

        northWallPos = new Vector3(0.0f, 4.0f, 5 * EnvironmentSettings.scaleZ + 1.0f);
        northWall.transform.position = northWallPos;

        eastWallPos = new Vector3(5 * EnvironmentSettings.scaleX + 1.0f, 4.0f, 0.0f);
        eastWall.transform.position = eastWallPos;

        southWallPos = new Vector3(0.0f, 4.0f, -5 * EnvironmentSettings.scaleZ - 1.0f);
        southWall.transform.position = southWallPos;

        westWallPos = new Vector3(-5 * EnvironmentSettings.scaleX - 1.0f, 4.0f, 0.0f);
        westWall.transform.position = westWallPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
