using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementSoundtest2 : MonoBehaviour
{
    public float movementThreshold = 0.1f; // Adjust this value based on your movement sensitivity
    public float speedThreshold = 0.5f;    // Adjust this value based on the minimum speed to trigger sound
    public float soundInterval = 0.2f;     // Adjust this value for the time between sounds
    public ShowFootstepUI FootstepManager;
    private bool isMoving = false;
    private float timer = 0f;
    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        // Check if the character is moving based on its position change
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movement.magnitude > movementThreshold)
        {
            float distance = Vector3.Distance(lastPosition, transform.position);
            float speed = distance / Time.deltaTime;

            // Check if the character is moving above the speed threshold
            if (speed > speedThreshold)
            {
                if (!isMoving)
                {
                    // Start playing the sound when the character starts moving
                    AkSoundEngine.PostEvent("FootstepAsphalt", this.gameObject);
                    isMoving = true;
                    timer = 0f;
                    Debug.LogWarning("First Step Taken");
                    FootstepManager.FootstepTakenUI();
                }
                else
                {
                    // Increment the timer and play the sound at intervals
                    timer += Time.deltaTime;
                    if (timer >= soundInterval)
                    {
                        AkSoundEngine.PostEvent("FootstepAsphalt", this.gameObject);
                        timer = 0f;
                        Debug.LogWarning("Step Taken");
                        FootstepManager.FootstepTakenUI();
                    }
                }
            }
            else
            {
                // Stop playing the sound when the character is moving too slowly
                if (isMoving)
                {
                    isMoving = false;
                }
            }

            lastPosition = transform.position; // Update last position for the next frame
        }
        else
        {
            // Stop playing the sound when the character stops moving
            if (isMoving)
            {
                isMoving = false;
            }
        }
    }
}
