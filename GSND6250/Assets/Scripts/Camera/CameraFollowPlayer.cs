using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject target; // The player's transform to follow
    public float followSpeed = 5f; // Speed of camera following
    public float rotationSpeed = 3f; // Speed of camera rotation
    
    private Vector2 lookInput; // Stores the look input values

    private void Update()
    {
        // Follow the player()
        Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 1.5f, target.transform.position.z - 3f);
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        transform.position = newPosition;

        // Rotate the camera based on the "Look" action
        RotateCamera();
        // Rotate the player
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        // Get the look input values from the Input System
        lookInput = InputSystem.GetDevice<Mouse>().delta.ReadValue();

        // Rotate the player based on look input
        Vector3 eulerRotation = target.transform.eulerAngles;
        eulerRotation.y += lookInput.x * rotationSpeed;
        target.transform.rotation = Quaternion.Euler(eulerRotation);
    }

    private void RotateCamera()
    {
        // Get the look input values from the Input System
        lookInput = InputSystem.GetDevice<Mouse>().delta.ReadValue();

        // Rotate the camera based on look input
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x -= lookInput.y * rotationSpeed;
        eulerRotation.y += lookInput.x * rotationSpeed;
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
