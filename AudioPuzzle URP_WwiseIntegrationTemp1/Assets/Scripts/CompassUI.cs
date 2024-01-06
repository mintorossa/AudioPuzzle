using UnityEngine;
using UnityEngine.UI;

public class CompassUI : MonoBehaviour
{
    public Transform playerTransform;
    public Text compassText;

    private void Update()
    {
        if (playerTransform != null && compassText != null)
        {
            UpdateCompassUI();
        }
    }

    private void UpdateCompassUI()
    {
        // Get player's rotation in degrees
        float playerRotation = playerTransform.eulerAngles.y;

        // Convert the rotation to a cardinal direction
        string cardinalDirection = GetCardinalDirection(playerRotation);

        // Update the compass UI text
        compassText.text = "Heading: " + cardinalDirection;
    }

    private string GetCardinalDirection(float angle)
    {
        // Define cardinal directions
        string[] cardinalDirections = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };

        // Calculate the index based on the angle
        int index = Mathf.RoundToInt(angle / 45f) % 8;

        // Ensure the index is within valid range
        index = (index + 8) % 8;

        // Return the corresponding cardinal direction
        return cardinalDirections[index];
    }
}
