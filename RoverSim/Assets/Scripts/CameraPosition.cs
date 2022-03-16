using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(CameraPosition)
        if(CameraPosition.renderer)
            Camera.Position.renderer.enabled=false;
    }

    function OnTriggerEnter (other : Collider) {
    if(CameraPosition  other.gameObject.tag == "Rover" ){
        Camera.main.transform.position = CameraPosition.position;
        Camera.main.transform.rotation = CameraPosition.rotation;
    }
}
