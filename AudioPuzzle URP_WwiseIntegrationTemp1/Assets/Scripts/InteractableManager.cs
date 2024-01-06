using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableManager : MonoBehaviour
{
    private List<InteractableObject> interactableObjectsList = new List<InteractableObject>();
    private int currentObjectIndex = 0;
    public Text clueText; // Reference to a Text component to display the clue
    public float interactionDistance = 2f;
    public KeyCode interactionKey = KeyCode.E;
    public GameObject promptUI;
    
    
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Interactable") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                ShowPrompt();
                
                if (Input.GetKeyDown(interactionKey))
                {
                    // Add your interaction logic here
                    // For example, call a method on the interactable object
                    hit.collider.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
                    // Call SelectNextObject from InteractableManager
                    SelectNextObject();
                }
            }
            else
            {
                HidePrompt();
            }
        }
        else
        {
            HidePrompt();
        }
    }

    private void ShowPrompt()
    {
        if (promptUI != null)
        {
            promptUI.SetActive(true);
        }
    }

    private void HidePrompt()
    {
        if (promptUI != null)
        {
            promptUI.SetActive(false);
        }
    }

    private void Start()
    {
        InteractableObject[] interactableObjectsArray = FindObjectsOfType<InteractableObject>();
        interactableObjectsList.AddRange(interactableObjectsArray);

        // Sort the list based on orderNumber
        interactableObjectsList.Sort((obj1, obj2) => obj1.orderNumber.CompareTo(obj2.orderNumber));

        if (interactableObjectsList.Count > 0)
        {
            SelectNextObject();
        }
        else
        {
            Debug.LogWarning("No objects with InteractableObject script found.");
        }
    }

    private void SelectNextObject()
    {
        if (currentObjectIndex > 0)
        {
            interactableObjectsList[currentObjectIndex - 1].gameObject.tag = "Untagged";
        }

        interactableObjectsList[currentObjectIndex].gameObject.tag = "Interactable";
        DisplayClue(); // Call the method to display the clue
        currentObjectIndex = (currentObjectIndex + 1) % interactableObjectsList.Count;
    }

    private void DisplayClue()
    {
        // Check if a Text component is assigned for displaying the clue
        if (clueText != null)
        {
            // Set the Text component's text to the writtenClue of the current object
            clueText.text = interactableObjectsList[currentObjectIndex].writtenClue;
        }
        else
        {
            Debug.LogWarning("No Text component assigned for displaying clues.");
        }
    }
}
