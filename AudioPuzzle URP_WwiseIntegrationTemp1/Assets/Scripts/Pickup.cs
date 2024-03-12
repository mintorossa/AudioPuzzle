
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int orderNumber = 0;

    [SerializeField]
    private AK.Wwise.Event PickupSFX = null;

    public void PlayPickupSFX()
    {
        PickupSFX.Post(gameObject);
    }
   

    // Define any specific behavior for interactable objects here
}
