using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour
{
    public Transform player;
    public float speedMultiplier = 1.0f;

    private Vector3 previousPlayerPosition;

    private void Start()
    {
        // Initialize the previous player position
        previousPlayerPosition = player.position;
    }

    private void Update()
    {
        // Calculate the player's movement vector
        Vector3 playerMovement = (player.position - previousPlayerPosition) * speedMultiplier;

        // Invert the horizontal and forward movement
        playerMovement.x = -playerMovement.x;
        playerMovement.z = -playerMovement.z;

        // Update the object's position based on the inverted movement
        transform.position += playerMovement;

        // Update the previous player position for the next frame
        previousPlayerPosition = player.position;
    }
}
