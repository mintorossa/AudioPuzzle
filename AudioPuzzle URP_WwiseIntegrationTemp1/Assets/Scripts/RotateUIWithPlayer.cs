using UnityEngine;

public class RotateUIWithPlayer : MonoBehaviour
{
    public Transform playerCharacter; // Assign the player character's transform in the Unity Editor
    public float rotationSpeed = 5f; // Adjust the speed of rotation as needed

    // Update is called once per frame
    void Update()
    {
        if (playerCharacter != null)
        {
            // Preserve existing rotation values
            Vector3 currentRotation = transform.rotation.eulerAngles;

            // Get the player character's Z rotation
            float playerZRotation = playerCharacter.eulerAngles.y;

            // Set the UI image's rotation preserving existing X and Y values
            transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, playerZRotation);

            
        }
        else
        {
            Debug.LogError("Player character not assigned to RotateUIWithPlayer script!");
        }
    }
}
