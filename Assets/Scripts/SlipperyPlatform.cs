using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyPlatform : MonoBehaviour
{
    // Create a new Physics Material 2D in the Inspector and assign it to this variable
    [SerializeField] private PhysicsMaterial2D slipperyMaterial;

    void Start()
    {
        // Get the Collider2D component attached to this game object
        Collider2D collider = GetComponent<Collider2D>();

        // Assign the slippery material to the collider
        collider.sharedMaterial = slipperyMaterial;
    }
}