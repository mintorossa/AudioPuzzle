using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform targetPoint; // The destination where you want to teleport the player

    // Call this method to teleport the player to the target point
    public void TeleportPlayer()
    {
        if (targetPoint != null)
        {
            transform.position = targetPoint.position;
        }
        else
        {
            Debug.LogWarning("Target point is not assigned!");
        }
    }
}
