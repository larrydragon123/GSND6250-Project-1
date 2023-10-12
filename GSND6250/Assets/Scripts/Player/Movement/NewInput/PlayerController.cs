using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool groundedPlayer;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevents rigidbody from rotating due to collisions.
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
        Debug.Log("is ground:" + groundedPlayer);
    }

    void Update()
    {
        groundedPlayer = Physics.Raycast(transform.position, Vector3.down, 0.6f, LayerMask.GetMask("Default"));

        // Get the camera's forward and right vectors (in world space)
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Zero out the y-component to make the movement on the XZ plane
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 move = cameraForward * movementInput.y + cameraRight * movementInput.x;
        Vector3 desiredVelocity = move * playerSpeed;

        // Apply the desired velocity to the rigidbody's velocity
        rb.velocity = new Vector3(desiredVelocity.x, rb.velocity.y, desiredVelocity.z);

        // Changes the height position of the player
        if (jumped && groundedPlayer)
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(jumpHeight * -2.0f * gravityValue), rb.velocity.z);
        }

        // Apply gravity to the rigidbody
        rb.AddForce(Vector3.up * gravityValue, ForceMode.Acceleration);
    }

    //draw gizmos to show the raycast
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * 0.6f);
    }
}
