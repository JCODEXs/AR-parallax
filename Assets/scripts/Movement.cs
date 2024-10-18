using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.3f; // Movement speed
    public Vector3 localMovement; // Movement in local space (set in Unity Inspector)
    private Vector3 startPosition; // Original position in world space
    private Vector3 endPosition; // Target position in world space
    private bool isMovingRight = true; // Initial movement direction

    void Start()
    {
        // Store the starting position in world space
        startPosition = transform.position;

        // Calculate the end position based on local movement direction, converted to world space
        endPosition = startPosition + transform.TransformDirection(localMovement);
    }

    void Update()
    {
        // Move towards either the end position or the start position
        Vector3 targetPosition = isMovingRight ? endPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the object is close enough to the target position, switch direction
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isMovingRight = !isMovingRight; // Flip direction when reaching the target
        }
    }
}
