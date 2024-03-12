using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    private List<Pickup> interactableObjectsList = new List<Pickup>();
    private int currentObjectIndex = 0;
    
    public float interactionDistance = 2f;
    public GameObject PickupAnimation;
    private GameObject CurrentPickupAnimation;
    
    
   
    
    
    
    
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Pickup") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Pickup"))
            {
                Vector3 spawnPosition = interactableObjectsList[currentObjectIndex - 1].gameObject.transform.position;
                CurrentPickupAnimation = Instantiate(PickupAnimation, spawnPosition, Quaternion.identity);
                CurrentPickupAnimation.gameObject.SetActive(true);
                interactableObjectsList[currentObjectIndex - 1].PlayPickupSFX();
                SelectNextObject();
                
                
            }
            
        }
        
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
