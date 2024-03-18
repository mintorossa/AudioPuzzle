using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DistanceChecker : MonoBehaviour
{
    public Image fadeOverlay; // Reference to the UI image covering the screen
    public float fadeDuration = 1f; // Duration of fade in/out
    public Transform player; // Reference to the player (assign in the Inspector)
    private Vector3 targetObject; // Reference to the position of the target game object 
    public float triggerDistance = 80.0f; // Set your desired trigger distance
    private float distance; // Current distance between player and target object
    public Transform targetLocation; // The destination where you want to move the player
    public PickupManager pickupManager;
    public CharacterController characterController; 
    public KeyCode key = KeyCode.E; // Define the key to listen for

    void Start()
    {
        fadeOverlay.gameObject.SetActive(true);
        StartCoroutine(FadeToNormal());
    }
    
    void Update()
    {
        // Calculate the distance between the player and the target object
        targetObject = pickupManager.interactableObjectsList[pickupManager.currentObjectIndex - 1].gameObject.transform.position;
        distance = Vector3.Distance(player.position, targetObject);
        
        // Check if the distance exceeds the trigger distance
        if (distance > triggerDistance)
        {
            // Call your custom method (e.g., HandleDistanceExceeded())
            HandleDistanceExceeded();
        }
        if (Input.GetKeyDown(key))
        {
            HandleDistanceExceeded();
        }
    }

    void HandleDistanceExceeded()
    {
        // Implement your custom logic here
        Debug.Log($"Distance exceeded! Player is {distance} units away from {pickupManager.interactableObjectsList[pickupManager.currentObjectIndex - 1].name}.");
        TeleportPlayer();
        // You can add more actions or behaviors as needed.
    }

    public void TeleportPlayer()
    {
        StartCoroutine(FadeInOut());
    }

    
    IEnumerator FadeInOut()
    {
        yield return FadeToBlack(); // Fade from normal to black
        yield return MovePlayer(); // Move the player
        yield return new WaitForSeconds(1f); // Wait for 1 second at black
        yield return FadeToNormal(); // Fade from black to normal
    }

    IEnumerator FadeToBlack()
    {
        float timer = 0f;
        Color startColor = Color.clear;
        Color endColor = Color.black;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeOverlay.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            yield return null;
        }

        fadeOverlay.color = endColor;
    }

    IEnumerator FadeToNormal()
    {
        float timer = 0f;
        Color startColor = Color.black;
        Color endColor = Color.clear;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeOverlay.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            yield return null;
        }

        fadeOverlay.color = endColor;
    }
    IEnumerator MovePlayer()
    {
        // Disable Character Controller to properly teleport
        characterController.enabled = false;

            // Check if it's first object in the pickupManager list
            if (pickupManager.currentObjectIndex == 1 )
            {
                // Move player to the default position set from Inspector
                player.position = targetLocation.position; 
                // Debug.Log("EKeyTeleport Coordinates " + targetLocation); // This continously reports the targetLocation, until the player is teleported
            }

            if (pickupManager.currentObjectIndex != 1)
            {
                // Change targetLocation to the position of the previous object in pickupmanager list
                targetLocation.position = pickupManager.interactableObjectsList[pickupManager.currentObjectIndex - 2].gameObject.transform.position;
                // Debug.Log("EKeyTeleport Coordinates " + targetLocation);
                // Move player
                player.position = targetLocation.position;
            }

        // Reenable CharacterController
        characterController.enabled = true;
        yield return null;
    }
}
