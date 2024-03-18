using UnityEngine;

public class EKeyTeleport : MonoBehaviour
{
    public KeyCode key = KeyCode.E; // Define the key to listen for
    public CharacterController characterController;
    public Transform player; // Reference to the player GameObject
    public PickupManager pickupManager;
    private Vector3 spawnPos;

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            characterController.enabled = false;

            if (pickupManager.currentObjectIndex == 1 )
            {
                spawnPos = new Vector3(1f, 1f, 1f);
                // player.position = spawnPos;
                Debug.Log("EKeyTeleport Coordinates " + spawnPos);
            }

            if (pickupManager.currentObjectIndex != 1)
            {
            spawnPos = pickupManager.interactableObjectsList[pickupManager.currentObjectIndex - 2].gameObject.transform.position;
            Debug.Log("EKeyTeleport Coordinates " + spawnPos);
            // Move player
            // player.position = spawnPos;
            }
            // Reenable CharacterController
            characterController.enabled = true;

        }
    }
}
