using UnityEngine;

public class GoalkeeperScript : MonoBehaviour
{
    private Animator goalkeeperAnimator;  // Reference to the Animator
    public Transform ballTransform;       // Reference to the ball's transform
    public float diveTriggerDistance = 22.0f;  // Distance to trigger dive
    public string diveLeftTrigger = "DiveLeft";  // Animator trigger for left dive
    public string diveRightTrigger = "DiveRight";  // Animator trigger for right dive
    public string idleTrigger = "Idle";    // Idle animation trigger
    public float earlyReactionBuffer = 1.0f;  // Buffer for earlier reaction

    private Rigidbody ballRigidbody; // Ball's Rigidbody to measure speed
    public MovementBoundary movementBoundary;  // Reference to the MovementBoundary script

    void Start()
    {
        goalkeeperAnimator = GetComponent<Animator>();

        if (ballTransform != null)
        {
            ballRigidbody = ballTransform.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (ballTransform == null || ballRigidbody == null || movementBoundary == null) return;

        float ballSpeed = ballRigidbody.linearVelocity.magnitude; // Get ball speed

        // Check if the ball is inside the boundary before reacting
        if (movementBoundary.IsBallInsideTrigger())
        {
            HandleGoalkeeperDive(ballSpeed); // Trigger dive based on ball position and speed
        }
        else
        {
            StopDiving(); // Stop diving if the ball is not in the boundary
        }
    }

    // Handle the dive decision based on ball position and speed
    public void HandleGoalkeeperDive(float ballSpeed)
    {
        // Calculate ball position relative to the goalkeeper
        Vector3 directionToBall = ballTransform.position - transform.position;
        float xDifference = directionToBall.x;
        float zDifference = directionToBall.z;

        // Adjust reaction distance based on ball speed
        float adjustedXDistance = Mathf.Abs(xDifference) - earlyReactionBuffer * ballSpeed;

        // If the ball is within the dive trigger distance, choose a dive direction
        if (adjustedXDistance < diveTriggerDistance)
        {
            TriggerDive(zDifference);
        }
    }

    // Trigger the appropriate dive animation
    void TriggerDive(float zDifference)
    {
        if (zDifference > 0) // Ball is to the right
        {
            goalkeeperAnimator.SetTrigger(diveRightTrigger);
        }
        else if (zDifference < 0) // Ball is to the left
        {
            goalkeeperAnimator.SetTrigger(diveLeftTrigger);
        }
    }

    // Stop diving and reset animation to idle
    public void StopDiving()
    {
        goalkeeperAnimator.ResetTrigger(diveRightTrigger);
        goalkeeperAnimator.ResetTrigger(diveLeftTrigger);
        goalkeeperAnimator.SetTrigger(idleTrigger);
    }
}













