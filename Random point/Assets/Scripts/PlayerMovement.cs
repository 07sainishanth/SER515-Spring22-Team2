using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    int wholeNumber = 3;
    float decimalNumber = 3.45f;
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         float horizantalInput = Input.GetAxis("Horizontal");
         float verticallInput = Input.GetAxis("Vertical");

         rb.velocity = new Vector3(horizantalInput*10f, rb.velocity.y, verticallInput*10f);
        
         if (Input.GetButtonDown("Jump"))
         {
             rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
         }
    }
}
