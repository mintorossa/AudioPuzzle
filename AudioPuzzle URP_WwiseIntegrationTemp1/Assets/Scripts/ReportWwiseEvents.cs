using UnityEngine;

public class AkAmbientEventReporter : MonoBehaviour
{
    void Start()
    {
        // Get all AkAmbient components attached to this game object
        AkAmbient[] akAmbients = GetComponents<AkAmbient>();

        if (akAmbients.Length > 0)
        {
            Debug.Log($"Found {akAmbients.Length} AkAmbient scripts attached to {gameObject.name}:");

            foreach (AkAmbient akAmbient in akAmbients)
            {
                string audioEventName = akAmbient.name;
                Debug.Log($"- Audio event name: {audioEventName}");
            }
        }
        else
        {
            Debug.LogWarning($"No AkAmbient scripts found on {gameObject.name}.");
        }
    }
}
