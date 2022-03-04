using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is responsible for erecting the monoliths in the navigation scene.
 * 
 * Author: David Bieganski
 */
public class MonolithErector : MonoBehaviour
{
    Vector3 up;
    bool done;
    Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        up = new Vector3(0.0f, 0.1f, 0.0f);
        done = false;
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y >= 20)
        {
            done = true;
            rBody.isKinematic = false;
        }
        if (!done) transform.Translate(up, Space.World);
    }
}
