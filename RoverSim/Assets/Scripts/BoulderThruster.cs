using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is responsible for applying an intial force to the boulder objects at beginning of scene.
 * 
 * Author: David Bieganski
 */
public class BoulderThruster : MonoBehaviour
{
    public string fromDirection;

    Rigidbody rBody;
    float mass;
    Vector3 startPosition;
    Vector3 forceDirection;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        int velocityFactor = (int) (20000 / rBody.mass); 
        float angle = Random.Range(-Mathf.PI * 15 / 16, Mathf.PI * 15 / 16);
        switch (fromDirection)
        {
            case ("West"):
                float zPosition = Random.Range(-1.0f, 1.0f) * (5 * EnvironmentSettings.scaleZ - 2.0f);
                startPosition = new Vector3(-5 * EnvironmentSettings.scaleX + 1.0f, 20.0f, zPosition);
                transform.localPosition = startPosition;
                forceDirection = new Vector3(velocityFactor * (1 - Mathf.Abs(Mathf.Sin(angle))), 0.0f, velocityFactor * Mathf.Sin(angle));
                break;
            case ("North"):
                float xPosition = Random.Range(-1.0f, 1.0f) * (5 * EnvironmentSettings.scaleX - 2.0f);
                startPosition = new Vector3(xPosition, 20.0f, 5 * EnvironmentSettings.scaleX + 1.0f);
                transform.localPosition = startPosition;
                forceDirection = new Vector3(velocityFactor * Mathf.Sin(angle), 0.0f, -velocityFactor * (1 - Mathf.Abs(Mathf.Sin(angle))));
                break;
            case ("East"):
                zPosition = Random.Range(-1.0f, 1.0f) * (5 * EnvironmentSettings.scaleZ - 2.0f);
                startPosition = new Vector3(5 * EnvironmentSettings.scaleX + 1.0f, 20.0f, zPosition);
                transform.localPosition = startPosition;
                forceDirection = new Vector3(-velocityFactor * (1 - Mathf.Abs(Mathf.Sin(angle))), 0.0f, velocityFactor * Mathf.Sin(angle));
                break;
            case ("South"):
                xPosition = Random.Range(-1.0f, 1.0f) * (5 * EnvironmentSettings.scaleX - 2.0f);
                startPosition = new Vector3(xPosition, 20.0f, -5 * EnvironmentSettings.scaleX + 1.0f);
                transform.localPosition = startPosition;
                forceDirection = new Vector3(velocityFactor * Mathf.Sin(angle), 0.0f, velocityFactor * (1 - Mathf.Abs(Mathf.Sin(angle))));
                break;
        }
        rBody.AddForce(forceDirection, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
