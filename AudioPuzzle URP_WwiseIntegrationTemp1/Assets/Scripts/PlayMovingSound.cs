using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementSound : MonoBehaviour
{
    public float movementThreshold = 0.1f; // Adjust this value based on your movement sensitivity
   
    private bool isMoving = false;


    private void Update()
    {
        // Check if the character is moving based on its position change
        float movement = Input.GetAxis("Vertical") + Input.GetAxis("Horizontal");
        if (Mathf.Abs(movement) > movementThreshold)
        {
            if (!isMoving)
            {
                // Start playing the sound when the character starts moving
                
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                // Stop playing the sound when the character stops moving
                
                isMoving = false;
            }
        }
    }
}

