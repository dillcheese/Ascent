using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloat : MonoBehaviour
{
    private float speed = 0.75f; // Speed of the floating animation
    private static float height = 0.25f; // Height of the floating animation

    private Vector3 startPos;

    private void Start()
    {
        // Save the starting position of the object
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculate the new position of the object
        Vector3 newPos = startPos;
        newPos.y += Mathf.Sin(Time.time * speed) * height;

        // Move the object to the new position
        transform.position = newPos;
    }
}