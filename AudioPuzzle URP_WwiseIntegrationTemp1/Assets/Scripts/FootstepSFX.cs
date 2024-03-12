using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FootstepSFX : MonoBehaviour
{
    public GameObject LeftFoot;  // Assign to script for left foot
    public GameObject RightFoot;  // Assign to script for right foot
    private int callCount = 0;

    public void FootstepTakenSFX()
    {
        callCount++;
        
        // Check if the number of calls is odd or even
        if (callCount % 2 == 1)
        {
            // Odd number of calls
           AkSoundEngine.PostEvent("Footstep" , LeftFoot.gameObject);
            
        }
        else
        {
            // Even number of calls
            AkSoundEngine.PostEvent("Footstep" , RightFoot.gameObject);
        }
    }
}