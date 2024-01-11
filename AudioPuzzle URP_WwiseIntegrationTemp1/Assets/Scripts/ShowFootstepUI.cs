using UnityEngine;
    
public class ShowFootstepUI : MonoBehaviour
{
    public FadeInOutUI LeftFoot;  // Assign to script for left foot
    public FadeInOutUI RightFoot;  // Assign to script for right foot
    private int callCount = 0;

    public void FootstepTakenUI()
    {
        callCount++;
        
        // Check if the number of calls is odd or even
        if (callCount % 2 == 1)
        {
            // Odd number of calls
            LeftFoot.TriggerFadeInOut();
            
        }
        else
        {
            // Even number of calls
            RightFoot.TriggerFadeInOut();
        }
    }
}
