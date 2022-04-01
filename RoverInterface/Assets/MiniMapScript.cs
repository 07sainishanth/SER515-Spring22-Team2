using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
   public transform player;

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y=transform.position.y;
        transform.position = new position;

        transform.rotation = Quaternon.Euler(90f,player.eulerAngles.y, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
