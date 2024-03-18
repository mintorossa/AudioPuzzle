using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeleporter : MonoBehaviour
{
    public Image fadeOverlay; // Reference to the UI image covering the screen
    public float fadeDuration = 1f; // Duration of fade in/out
    public Transform player; // Reference to the player GameObject
    public Transform targetLocation; // The destination where you want to move the player
    public CharacterController characterController;
    

    public void TeleportPlayer()
    {
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        yield return FadeToBlack(); // Fade from normal to black
        // Disable Character Controller to properly teleport
        characterController.enabled = false;
        // Move player
        player.position = targetLocation.position;
        // Reenable CharacterController
        characterController.enabled = true;
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

    
}
