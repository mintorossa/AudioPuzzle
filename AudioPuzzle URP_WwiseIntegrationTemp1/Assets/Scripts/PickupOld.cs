using UnityEngine;

public class PickupOld : MonoBehaviour
{
    public int NumberValue;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupManagerOld pickupManager = FindObjectOfType<PickupManagerOld>();

            if (pickupManager != null)
            {
                pickupManager.PlayerEnteredRadius(this);
            }
        }
    }
}
