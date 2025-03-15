using UnityEngine;

public class MovementBoundary : MonoBehaviour
{
    public GoalkeeperScript goalkeeperScript; // Reference to the GoalkeeperScript
    
    private bool ballInsideTrigger = false;  // To track if the ball is inside the trigger

    // When the ball enters the trigger box
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballInsideTrigger = true;  // Ball has entered the trigger
            Rigidbody ballRigidbody = other.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                float ballSpeed = ballRigidbody.linearVelocity.magnitude; // Get ball speed

                // Trigger dive based on the ball's position
                goalkeeperScript.HandleGoalkeeperDive(ballSpeed);
            }
        }
    }

    // When the ball exits the trigger box, stop diving
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballInsideTrigger = false;  // Ball has exited the trigger
            goalkeeperScript.StopDiving();
        }
    }

    // Method to check if the ball is inside the trigger box
    public bool IsBallInsideTrigger()
    {
        return ballInsideTrigger;  // Return whether the ball is inside the trigger
    }
}


