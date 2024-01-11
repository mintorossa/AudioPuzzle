using UnityEngine;
using UnityEngine.UI;

public class HueChanger : MonoBehaviour
{
    public Image uiImage;
    public float hueOffset = 0f;

    void Start()
    {
        if (uiImage == null)
        {
            Debug.LogError("UI Image not assigned to the script.");
            return;
        }

        ChangeHue(uiImage, hueOffset);
    }

    void ChangeHue(Image image, float offset)
    {
        // Get the current color of the UI image
        Color currentColor = image.color;

        // Convert the RGB color to HSL
        Color.RGBToHSV(currentColor, out float h, out float s, out float v);

        // Apply the hue offset
        h = (h + offset) % 1.0f;

        // Convert the modified HSL color back to RGB
        Color newColor = Color.HSVToRGB(h, s, v);

        // Apply the new color to the UI image
        image.color = newColor;
    }
}
