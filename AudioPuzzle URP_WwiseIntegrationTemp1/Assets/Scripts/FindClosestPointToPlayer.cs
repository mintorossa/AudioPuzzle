using UnityEngine;

public class ClosestPointOnLine : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform player;
    public Transform targetObject;

    void Update()
    {
        // Calculate the direction vector of the line
        Vector3 lineDirection = point2.position - point1.position;

        // Calculate the vector from point1 to the player
        Vector3 point1ToPlayer = player.position - point1.position;

        // Calculate the distance along the line where the closest point is
        float t = Vector3.Dot(point1ToPlayer, lineDirection) / Vector3.Dot(lineDirection, lineDirection);

        // Clamp t to ensure the closest point is within the line segment
        t = Mathf.Clamp01(t);

        // Calculate the closest point on the line
        Vector3 closestPoint = point1.position + t * lineDirection;

        // Move the targetObject to the closest point on the line
        targetObject.position = closestPoint;

        // Optional: Visualize the line and closest point
        Debug.DrawLine(point1.position, point2.position, Color.blue);
        Debug.DrawLine(player.position, closestPoint, Color.red);
    }
}
