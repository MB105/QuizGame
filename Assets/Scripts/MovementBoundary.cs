using UnityEngine;
using TMPro;

public class MovementBoundary : MonoBehaviour
{
    public GoalkeeperScript goalkeeperScript; // Reference to the GoalkeeperScript
    private bool ballInsideTrigger = false;  // To track if the ball is inside the trigger

    public TextMeshProUGUI goalMessage; // Reference to show the message
    public float messageDuration = 4f;

    // When the ball enters the trigger box (MovementBoundary)
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

    // When the ball exits the trigger box (MovementBoundary)
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballInsideTrigger = false;  // Ball has exited the trigger

            // Check if the ball hasn't already scored a goal in the GoalTrigger area
            if (!GoalTrigger.isGoal) // You'll need a static variable `isGoal` in GoalTrigger to track if a goal is scored
            {
                // Show a "No goal" message because the ball exited the boundary without scoring
                ShowGoalMessage("Du ramte ved siden af. Du får ingen nøgle.");
            }
            
            goalkeeperScript.StopDiving();
            GameSceneManager.instance.LoadSceneWithDelay("quizgame", 6.0f);
        }
    }

    // Method to check if the ball is inside the trigger box
    public bool IsBallInsideTrigger()
    {
        return ballInsideTrigger;  // Return whether the ball is inside the trigger
    }

    // Implement GoalMessageManager to show the goal message
    void ShowGoalMessage(string message)
    {
        GoalMessageManager.instance.ShowMessage(message);

        
    }
}




