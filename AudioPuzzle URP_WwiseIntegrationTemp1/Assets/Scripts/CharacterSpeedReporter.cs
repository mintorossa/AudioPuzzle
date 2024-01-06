using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpeedReporter : MonoBehaviour
{
    public float movementThreshold = 0.1f; // Adjust this value based on your movement sensitivity
    private CharacterController characterController;
    
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the character is moving based on its input
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movement.magnitude > movementThreshold)
        {
            // Calculate the character's speed
            float speed = CalculateSpeed();

            // Report the speed (you can replace this with your desired logic)
            Debug.Log("Character Speed: " + speed + " units per second");
        }
    }

    private float CalculateSpeed()
    {
        // Calculate the character's speed based on the character controller velocity
        Vector3 horizontalVelocity = new Vector3(characterController.velocity.x, 0f, characterController.velocity.z);
        return horizontalVelocity.magnitude;
    }
}
