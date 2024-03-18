using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    public List<Pickup> interactableObjectsList = new List<Pickup>();
    public int currentObjectIndex = 0;
    public KeyCode key = KeyCode.E; // Define the key to listen for
    public float interactionDistance = 2f;
    public GameObject PickupAnimation;
    private GameObject CurrentPickupAnimation;
    public Vector3 spawnPosition = new Vector3(1f, 1f, 1f);
    private Vector3 spawnPos;
    
    
   
    
    
    
    
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Pickup") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Pickup"))
            {
                Vector3 spawnPosition = interactableObjectsList[currentObjectIndex - 1].gameObject.transform.position;
                Debug.Log("PickupManager Coordinates" + spawnPosition);
                CurrentPickupAnimation = Instantiate(PickupAnimation, spawnPosition, Quaternion.identity);
                CurrentPickupAnimation.gameObject.SetActive(true);
                interactableObjectsList[currentObjectIndex - 1].PlayPickupSFX();
                SelectNextObject();
                
                
            }
            
        }

        /* if (Input.GetKeyDown(key))
        {
            
            spawnPos = interactableObjectsList[currentObjectIndex - 1].gameObject.transform.position;
            
            // player.position = spawnPos;
            Debug.Log("Your message: " + spawnPos);
            
            
        } */
    }
    
    

    

    private void Start()
    {
        Pickup[] interactableObjectsArray = FindObjectsOfType<Pickup>();
        interactableObjectsList.AddRange(interactableObjectsArray);

        // Sort the list based on orderNumber
        interactableObjectsList.Sort((obj1, obj2) => obj1.orderNumber.CompareTo(obj2.orderNumber));
        // Disable all game objects
        foreach (var obj in interactableObjectsList)
        {
            obj.gameObject.SetActive(false);
            AkSoundEngine.SetSwitch("EventEnabled", "Off", this.gameObject);
        }

        if (interactableObjectsList.Count > 0)
        {
            SelectNextObject();
            // Debug.Log("SelectNextObject Called");
        }
        else
        {
            Debug.LogWarning("No objects with Pickup script found.");
        }
    }

    private void SelectNextObject()
    {
        if (currentObjectIndex > 0)
        {
            interactableObjectsList[currentObjectIndex - 1].gameObject.tag = "Untagged";
            interactableObjectsList[currentObjectIndex - 1].gameObject.SetActive(false);
            AkSoundEngine.SetSwitch("EventEnabled", "Off", interactableObjectsList[currentObjectIndex - 1].gameObject);
            // Debug.Log("Object set to untagged");
        }
        
        interactableObjectsList[currentObjectIndex].gameObject.SetActive(true);
        interactableObjectsList[currentObjectIndex].gameObject.tag = "Pickup";
        AkSoundEngine.SetSwitch("EventEnabled", "On", interactableObjectsList[currentObjectIndex].gameObject);
        // Debug.Log("Object set to Pickup tag");
        
        currentObjectIndex = (currentObjectIndex + 1) % interactableObjectsList.Count;
    }

    
}
