using UnityEngine;

public class SetClosestPosition : MonoBehaviour
{
    void Update()
    {
        // Set the position to (x, y, z)
        Vector3 newPosition = new Vector3(1.0f, 2.0f, 3.0f);
        SetPosition(newPosition);
    }

    void SetPosition(Vector3 newPosition)
    {
        // Assuming this script is attached to the GameObject whose position you want to change
        transform.position = newPosition;

        // If the script is attached to a different GameObject, you can use the following line instead:
        // GetComponent<Transform>().position = newPosition;
    }
}
