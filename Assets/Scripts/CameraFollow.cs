using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform

    private float screenHeight;
    private float topScreenBound;
    private float bottomScreenBound;

    void Start()
    {
        // Calculate screen height in world units
        screenHeight = Camera.main.orthographicSize * 2.0f;

        // Calculate screen bounds
        CalculateScreenBounds();
    }

    void Update()
    {
        // Check if player has jumped out of view
        if (player.position.y > topScreenBound)
        {
            // Snap camera upwards by one screen height
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + screenHeight, transform.position.z);
            transform.position = newPosition;

            // Recalculate screen bounds
            CalculateScreenBounds();
        }
        // Check if player has fallen out of view
        else if (player.position.y < bottomScreenBound)
        {
            // Snap camera downwards by one screen height
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - screenHeight, transform.position.z);
            transform.position = newPosition;

            // Recalculate screen bounds
            CalculateScreenBounds();
        }
    }

    void CalculateScreenBounds()
    {
        topScreenBound = transform.position.y + (screenHeight / 2);
        bottomScreenBound = transform.position.y - (screenHeight / 2);
    }
}