using UnityEngine;

public class GoalkeeperScript : MonoBehaviour
{
    private Animator goalkeeperAnimator;  // Reference to the Animator
    public Transform ballTransform;       // Reference to the ball's transform
    public float diveTriggerDistance = 22.0f;  // Distance to trigger dive
    public string diveLeftTrigger = "DiveLeft";  // Animator trigger for left dive
    public string diveRightTrigger = "DiveRight";  // Animator trigger for right dive
    public string idleTrigger = "Idle";    // Idle animation trigger
    public float earlyReactionBuffer = 1.0f;  // Buffer to trigger reaction earlier (adjust this value as needed)
    
    private Rigidbody ballRigidbody; // Ball's Rigidbody to measure speed

    // BoxCollider to define the boundary of the goalkeeper's movement
    public BoxCollider movementBoundary;

    void Start()
    {
        // Get the Animator component from the goalkeeper
        goalkeeperAnimator = GetComponent<Animator>();

        // Get the ball's Rigidbody to measure its speed
        if (ballTransform != null)
        {
            ballRigidbody = ballTransform.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (ballTransform == null || ballRigidbody == null) return; // Ensure ball exists and has Rigidbody

        // Measure X and Z distance between goalkeeper and ball
        Vector3 directionToBall = ballTransform.position - transform.position;
        float xDifference = directionToBall.x; // Extract X-axis difference
        float zDifference = directionToBall.z;

        // Calculate ball speed
        float ballSpeed = ballRigidbody.linearVelocity.magnitude;

        // Skip if ball is moving too slowly
        if (ballSpeed < 1f) return;

        // Add a buffer to the X distance for early reaction (this factor can be adjusted)
        float adjustedXDistance = Mathf.Abs(xDifference) - earlyReactionBuffer * ballSpeed;

        // Debug logs to check the ball's position and speed
        Debug.Log("Ball Position: " + ballTransform.position);
        Debug.Log("X Difference: " + xDifference);
        Debug.Log("Ball Speed: " + ballSpeed);
        Debug.Log("Adjusted X Distance: " + adjustedXDistance);

        // Trigger dive animation if the adjusted X distance is within the trigger distance
        if (adjustedXDistance < diveTriggerDistance)
        {
            Debug.Log("Ball is close enough, checking dive direction...");

            // Trigger the dive based on the ball's Z-axis direction
            if (zDifference > 0) // Ball is to the right
            {
                Debug.Log("Diving Right!");
                goalkeeperAnimator.SetTrigger(diveRightTrigger);
            }
            else if (zDifference < 0) // Ball is to the left
            {
                Debug.Log("Diving Left!");
                goalkeeperAnimator.SetTrigger(diveLeftTrigger);
            }
        }

        // Constrain goalkeeper within movement boundary (box)
        ConstrainMovement();
    }

    void ConstrainMovement()
    {
        if (movementBoundary != null)
        {
            // Get the boundaries of the movement box
            Vector3 min = movementBoundary.bounds.min; // Minimum bounds (bottom-left-back)
            Vector3 max = movementBoundary.bounds.max; // Maximum bounds (top-right-front)

            // Constrain the goalkeeper's position within the bounds of the box
            float clampedX = Mathf.Clamp(transform.position.x, min.x, max.x);
            float clampedY = Mathf.Clamp(transform.position.y, min.y, max.y);
            float clampedZ = Mathf.Clamp(transform.position.z, min.z, max.z);

            // Apply the constrained position to the goalkeeper
            transform.position = new Vector3(clampedX, clampedY, clampedZ);
        }
    }

    // Detect when the ball collides with the goalkeeper
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding with the goalkeeper is the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball hit the goalkeeper!");

            // Stop the dive animation and transition to idle
            goalkeeperAnimator.ResetTrigger(diveRightTrigger);
            goalkeeperAnimator.ResetTrigger(diveLeftTrigger);
            goalkeeperAnimator.SetTrigger(idleTrigger); // Transition to idle state
        }
    }
}














