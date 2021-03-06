using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is responsible for placing the physical objects in the navigation scene.
 * 
 * Author: David Bieganski
 */
public class ObjectPlacer : MonoBehaviour
{
    public GameObject spaceObject;
    public GameObject block;
    public GameObject largeBoulder;
    public GameObject colossalBoulder;
    public GameObject spaceMonolith;
    public GameObject navText;
    public GameObject turtlebot;
    public GameObject gopigo;
    public GameObject pDestroyer;
    public GameObject cameraRig;

    int frameCounter;
    GameObject rover;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos;
        Quaternion rot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

        for (int i = 0; i < EnvironmentSettings.spaceObjectCount; i++)
        {
            float xPos = Random.Range(-5 * EnvironmentSettings.scaleX, 5 * EnvironmentSettings.scaleX);
            float yPos = Random.Range(75, 125);
            float zPos = Random.Range(-5 * EnvironmentSettings.scaleZ, 5 * EnvironmentSettings.scaleZ);
            pos = new Vector3(xPos, yPos, zPos);
            Instantiate(spaceObject, pos, rot).SetActive(true);
            frameCounter = 0;
        }

        PyramidBuilder.block = block;
        for (int i = 0; i < EnvironmentSettings.pyramidCount; i++)
        {
            PyramidBuilder.levels = (int) Random.Range(10, 30);
            PyramidBuilder.xPos = Random.Range(-5 * EnvironmentSettings.scaleX, 5 * EnvironmentSettings.scaleX);
            PyramidBuilder.yPos = 0.0f;
            PyramidBuilder.zPos = Random.Range(-5 * EnvironmentSettings.scaleZ, 5 * EnvironmentSettings.scaleZ);
            PyramidBuilder.buildPyramid();
        }
        
        for (int i = 0; i < EnvironmentSettings.largeBoulderCount; i++)
        {
            int rnd = (int) Random.Range(1, 5);
            switch (rnd)
            {
                case 1:
                    GameObject lb = Instantiate(largeBoulder);
                    lb.GetComponent<BoulderThruster>().fromDirection = "West";
                    lb.SetActive(true);
                    break;
                case 2:
                    lb = Instantiate(largeBoulder);
                    lb.GetComponent<BoulderThruster>().fromDirection = "North";
                    lb.SetActive(true);
                    break;
                case 3:
                    lb = Instantiate(largeBoulder);
                    lb.GetComponent<BoulderThruster>().fromDirection = "East";
                    lb.SetActive(true);
                    break;
                case 4:
                    lb = Instantiate(largeBoulder);
                    lb.GetComponent<BoulderThruster>().fromDirection = "South";
                    lb.SetActive(true);
                    break;
            }
        }

        for (int i = 0; i < EnvironmentSettings.colossalBoulderCount; i++)
        {
            int rnd = (int)Random.Range(1, 5);
            switch (rnd)
            {
                case 1:
                    GameObject cb = Instantiate(colossalBoulder);
                    cb.GetComponent<BoulderThruster>().fromDirection = "West";
                    cb.SetActive(true);
                    break;
                case 2:
                    cb = Instantiate(colossalBoulder);
                    cb.GetComponent<BoulderThruster>().fromDirection = "North";
                    cb.SetActive(true);
                    break;
                case 3:
                    cb = Instantiate(colossalBoulder);
                    cb.GetComponent<BoulderThruster>().fromDirection = "East";
                    cb.SetActive(true);
                    break;
                case 4:
                    cb = Instantiate(colossalBoulder);
                    cb.GetComponent<BoulderThruster>().fromDirection = "South";
                    cb.SetActive(true);
                    break;
            }
        }

        for (int i = 0; i < EnvironmentSettings.spaceMonolithCount; i++)
        {
            float xPos = Random.Range(-5 * EnvironmentSettings.scaleX, 5 * EnvironmentSettings.scaleX);
            float yPos = -20.0f;
            float zPos = Random.Range(-5 * EnvironmentSettings.scaleZ, 5 * EnvironmentSettings.scaleZ);
            pos = new Vector3(xPos, yPos, zPos);
            Instantiate(spaceMonolith, pos, rot).SetActive(true);
        }

        // Select the model
        switch (EnvironmentSettings.robot)
        {
            case EnvironmentSettings.Robot.TURTLEBOT:
                turtlebot.SetActive(true);
                gopigo.SetActive(false);
                pDestroyer.SetActive(false);
                cameraRig.SetActive(false);
                rover = turtlebot;
                break;
            case EnvironmentSettings.Robot.GOPIGO:
                turtlebot.SetActive(false);
                gopigo.SetActive(true);
                pDestroyer.SetActive(false);
                cameraRig.SetActive(false);
                rover = gopigo;
                break;
            case EnvironmentSettings.Robot.P_DESTROYER:
                turtlebot.SetActive(false);
                gopigo.SetActive(false);
                pDestroyer.SetActive(true);
                cameraRig.SetActive(true);
                rover = pDestroyer;
                break;
        }

        // Randomly place the rover if pDestroyer
        {
            if (EnvironmentSettings.robot == EnvironmentSettings.Robot.P_DESTROYER)
            {

                float xPos = Random.Range(-5 * EnvironmentSettings.scaleX, 5 * EnvironmentSettings.scaleX);
                float yPos = 1.0f;
                float zPos = Random.Range(-5 * EnvironmentSettings.scaleZ, 5 * EnvironmentSettings.scaleZ);
                pos = new Vector3(xPos, yPos, zPos);
                rover.transform.position = pos;
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (frameCounter < 180)
        {
            frameCounter++;
                if (frameCounter == 180)
            {
                navText.SetActive(false);
            }
        }
    }
}
