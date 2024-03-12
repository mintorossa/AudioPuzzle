using System.Collections.Generic;
using UnityEngine;

public class PickupManagerOld : MonoBehaviour
{
    private List<PickupOld> pickups = new List<PickupOld>();

    void Start()
    {
        // Gather all game objects with Pickup script
        PickupOld[] pickupScripts = FindObjectsOfType<PickupOld>();
        pickups.AddRange(pickupScripts);

        // Disable all gathered game objects
        DisableAllPickups();

        // Enable the one with the lowest number value
        EnableLowestNumberPickup();
    }

    void DisableAllPickups()
    {
        foreach (PickupOld pickup in pickups)
        {
            pickup.gameObject.SetActive(false);
        }
    }

    void EnableLowestNumberPickup()
    {
        if (pickups.Count > 0)
        {
            PickupOld lowestNumberPickup = pickups[0];

            foreach (PickupOld pickup in pickups)
            {
                if (pickup.NumberValue < lowestNumberPickup.NumberValue)
                {
                    lowestNumberPickup = pickup;
                }
            }

            lowestNumberPickup.gameObject.SetActive(true);
        }
    }

    public void PlayerEnteredRadius(PickupOld pickup)
    {
        pickup.gameObject.SetActive(false);

        // Enable the one with a higher number value
        EnableNextHighestNumberPickup(pickup.NumberValue);
    }

    void EnableNextHighestNumberPickup(int currentNumberValue)
    {
        PickupOld nextHighestPickup = null;

        foreach (PickupOld pickup in pickups)
        {
            if (pickup.NumberValue > currentNumberValue && (nextHighestPickup == null || pickup.NumberValue < nextHighestPickup.NumberValue))
            {
                nextHighestPickup = pickup;
            }
        }

        if (nextHighestPickup != null)
        {
            nextHighestPickup.gameObject.SetActive(true);
        }
    }
}
