using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public GameObject objectToEnable;

    void Start()
    {
        // Ensure the object to enable is initially enabled
        objectToEnable.SetActive(true);
    }
    private bool isSwitchOn = false;

    void Update()
    {
        // Check if the 'X' key is pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Toggle the switch state
            ToggleSwitch();
        }
    }

    void ToggleSwitch()
    {
        // Toggle the switch state
        isSwitchOn = !isSwitchOn;

        // Perform actions based on the switch state
        if (isSwitchOn)
        {
            // Switch is ON, perform actions (e.g., turn on lights, play sound)
            Debug.Log("Black Screen turned ON");
            objectToEnable.SetActive(true);
        }
        else
        {
            // Switch is OFF, perform actions (e.g., turn off lights, stop sound)
            Debug.Log("Black Screen turned OFF");
            objectToEnable.SetActive(false);
        }
    }
}