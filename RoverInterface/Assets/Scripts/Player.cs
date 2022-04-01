using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyPressed;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rigidbodyComponent;


    private Vector2 turn;
    [SerializeField] private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        rigidbodyComponent.rotation = Quaternion.Euler(0, turn.x, 0);

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF = camF.normalized;
        camR = camR.normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        rigidbodyComponent.position += (camF* verticalInput + camR * horizontalInput) * Time.deltaTime * 5;

    }

    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(rigidbodyComponent.velocity.x, rigidbodyComponent.velocity.y, rigidbodyComponent.velocity.z);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length < 2)
        {
            return;
        }
        if (jumpKeyPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }
    }
}
