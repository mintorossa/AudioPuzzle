using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInOutUI : MonoBehaviour
{
    public Image uiImage; // Reference to the UI Image
    public float fadeInTime = 1.0f; // Time in seconds to fade in
    public float fadeOutTime = 1.0f; // Time in seconds to fade out

    private void Start()
    {
        // Ensure the UI image is initially hidden
        uiImage.gameObject.SetActive(false);
    }

    public void TriggerFadeInOut()
    {
        // Show the UI image
        uiImage.gameObject.SetActive(true);

        // Start fading in
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            // Calculate the current alpha value based on the elapsed time
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);

            // Set the alpha value of the UI image
            SetImageAlpha(alpha);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Start fading out after fading in
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutTime)
        {
            // Calculate the current alpha value based on the elapsed time
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);

            // Set the alpha value of the UI image
            SetImageAlpha(alpha);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Hide the UI image after fading out
        uiImage.gameObject.SetActive(false);
    }

    private void SetImageAlpha(float alpha)
    {
        // Get the current color of the UI image
        Color currentColor = uiImage.color;

        // Set the alpha value
        currentColor.a = alpha;

        // Apply the new color to the UI image
        uiImage.color = currentColor;
    }
}
